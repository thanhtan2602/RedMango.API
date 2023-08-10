using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RedMango.API.Data;
using RedMango.API.Models;
using RedMango.API.Models.Dto;
using RedMango.API.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RedMango.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private ApiResponse _response;
        private string secretKey;
        public AuthController(
            AppDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _response = new ApiResponse();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequest)
        {
            ApplicationUser applicationUser = _db.ApplicationUsers
                .FirstOrDefault(x => x.UserName.ToLower() == registerRequest.UserName.ToLower());

            if (applicationUser != null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }

            ApplicationUser newUser = new ApplicationUser
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.UserName,
                NormalizedEmail = registerRequest.UserName.ToUpper(),
                Name = registerRequest.Name,
            };
            try
            {
                var result = await _userManager.CreateAsync(newUser, registerRequest.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                    {
                        //create roles in db
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
                    }
                    if (registerRequest.Role.ToLower() == SD.Role_Admin)
                    {
                        await _userManager.AddToRoleAsync(newUser, SD.Role_Admin);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(newUser, SD.Role_Customer);
                    }

                    _response.StatusCode = System.Net.HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {

            }


            _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Error while registering");
            return BadRequest(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            ApplicationUser applicationUser = _db.ApplicationUsers
                .FirstOrDefault(x => x.UserName.ToLower() == loginRequest.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(applicationUser, loginRequest.Password);
            if (!isValid)
            {
                _response.Result = new LoginResponseDTO();
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password incorrect");
                return BadRequest(_response);
            }

            //wer have tp generate JWT Token
            var roles = await _userManager.GetRolesAsync(applicationUser);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secretKey);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("fullName", applicationUser.Name),
                    new Claim("id", applicationUser.Id.ToString()),
                    new Claim(ClaimTypes.Email, applicationUser.UserName),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginResponse = new LoginResponseDTO()
            {
                Email = applicationUser.Email,
                Token = tokenHandler.WriteToken(token)
            };

            if (string.IsNullOrEmpty(loginResponse.Email) || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.Result = new LoginResponseDTO();
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password incorrect");
                return BadRequest(_response);
            }

            _response.StatusCode = System.Net.HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }
    }
}
