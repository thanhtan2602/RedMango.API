using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedMango.API.Data;
using RedMango.API.Models;

namespace RedMango.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ApiResponse _response;
        public ShoppingCartController(AppDbContext db)
        {
            _db = db;
            _response = new ApiResponse();
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddOrUpdateItemInCart(string userId, int menuItemId, int updateQualityBy)
        {
            //logic
            //

            ShoppingCart shoppingCart = _db.ShoppingCarts.FirstOrDefault(x => x.UserId == userId);
            MenuItem menuItem = _db.MenuItems.FirstOrDefault(x => x.Id == menuItemId);
            if (menuItem == null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            if (shoppingCart == null && updateQualityBy > 0)
            {
                //create a shopping cart & add cart item
                ShoppingCart newCart = new ShoppingCart
                {
                    UserId = userId,
                };
                _db.ShoppingCarts.Add(newCart);
                _db.SaveChanges();

                CartItem newCartItem = new CartItem
                {
                    MenuItemId = menuItemId,
                    Quantity = updateQualityBy,
                    ShoppingCartId = newCart.Id,
                    MenuItem = null
                };
                _db.CartItems.Add(newCartItem);
                _db.SaveChanges();
            }
            return _response;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetShoppingCart(string userId)
        {
            try
            {
                ShoppingCart shoppingCart;
                if (string.IsNullOrEmpty(userId))
                {
                    shoppingCart = new ShoppingCart();
                }
                else
                {
                    shoppingCart = _db.ShoppingCarts
                    .Include(x => x.CartItems).ThenInclude(x => x.MenuItem)
                    .FirstOrDefault(x => x.UserId == userId);
                }

                if (shoppingCart.CartItems?.Count > 0)
                {
                    shoppingCart.CartTotal = shoppingCart.CartItems.Sum(x => x.Quantity * x.MenuItem.Price);
                }

                _response.Result = shoppingCart;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return _response;
        }
    }
}
