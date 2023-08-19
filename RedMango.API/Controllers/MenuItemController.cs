using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedMango.API.Data;
using RedMango.API.Models;
using RedMango.API.Models.Dto;
using System.Net;

namespace RedMango.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ApiResponse _response;

        public MenuItemController(AppDbContext db)
        {
            _db = db;
            _response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            _response.Result = _db.MenuItems;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{menuId:int}", Name = "GetMenuItem")]
        public async Task<IActionResult> GetMenuItem(int menuId)
        {
            if (menuId == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            MenuItem menuItem = _db.MenuItems.FirstOrDefault(x => x.Id == menuId);
            if (menuItem == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            _response.Result = menuItem;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateMenuItem([FromForm] MenuItemCreateDTO menuItemCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MenuItem menuItemToCreate = new MenuItem
                    {
                        Name = menuItemCreate.Name,
                        Price = menuItemCreate.Price,
                        Category = menuItemCreate.Category,
                        SpecialTag = menuItemCreate.SpecialTag,
                        Description = menuItemCreate.Description
                    };
                    _db.MenuItems.Add(menuItemToCreate);
                    _db.SaveChanges();
                    _response.Result = menuItemToCreate;
                    _response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetMenuItem", new { menuId = menuItemToCreate.Id }, _response);
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message.ToString());
            }

            return _response;
        }

        [HttpPut("{menuId:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateMenuItem(int menuId, [FromForm] MenuItemUpdateDTO menuItemUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    MenuItem menuItem = await _db.MenuItems.FindAsync(menuId);
                    if (menuItem == null)
                    {
                        return BadRequest();
                    }


                    menuItem.Name = menuItemUpdate.Name;
                    menuItem.Price = menuItemUpdate.Price;
                    menuItem.Category = menuItemUpdate.Category;
                    menuItem.SpecialTag = menuItemUpdate.SpecialTag;
                    menuItem.Description = menuItemUpdate.Description;

                    _db.MenuItems.Update(menuItem);
                    _db.SaveChanges();
                    _response.Result = menuItem;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message.ToString());
            }

            return _response;
        }
        
        [HttpDelete("{menuId:int}")]
        public async Task<ActionResult<ApiResponse>> DeleteMenuItem(int menuId)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    MenuItem menuItem = await _db.MenuItems.FindAsync(menuId);
                    if (menuItem == null)
                    {
                        return BadRequest();
                    }

                    _db.MenuItems.Remove(menuItem);
                    _db.SaveChanges();
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message.ToString());
            }

            return _response;
        }
    }
}
