using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedMango.API.Data;
using RedMango.API.Models;
using Stripe;

namespace RedMango.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;
        private ApiResponse _response;
        public PaymentController(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _response = new ApiResponse();
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> MakePayment(string userId)
        {
            ShoppingCart shoppingCart = _db.ShoppingCarts
                .Include(x=>x.CartItems)
                .ThenInclude(x=>x.MenuItem).FirstOrDefault(x=>x.UserId  == userId);

            if (shoppingCart == null || shoppingCart.CartItems == null || shoppingCart.CartItems.Count == 0)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            #region Create Payment Intent
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];
            shoppingCart.CartTotal = shoppingCart.CartItems.Sum(x => x.Quantity * x.MenuItem.Price);

            PaymentIntentCreateOptions options = new PaymentIntentCreateOptions
            {
                Amount = (int)(shoppingCart.CartTotal * 100),
                Currency = "usd",
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
            };
            PaymentIntentService service = new PaymentIntentService();
            PaymentIntent response = service.Create(options);
            shoppingCart.StripePaymentIntentId = response.Id;
            shoppingCart.ClientSecret = response.ClientSecret;
            #endregion

            _response.Result = shoppingCart;
            _response.StatusCode=System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
