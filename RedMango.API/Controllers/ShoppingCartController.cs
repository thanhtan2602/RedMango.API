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
        public async Task<ActionResult<ApiResponse>> AddOrUpdateItemInCart(string userId, int menuItemId, int updateQuantityBy)
        {
            // Shopping cart will have one entry per user id, even if a user has many items in cart
            // Cart items will have all the items in shopping cart for a user
            // updatequantityby will have count by with an items quantity needs to be updated
            // if it is -1 that means we have lower a count if it is 5 it means we have to add 5 count to existing count
            // if updatequantityby by is 0, item will be removed

            ShoppingCart shoppingCart = _db.ShoppingCarts.FirstOrDefault(x => x.UserId == userId);
            MenuItem menuItem = _db.MenuItems.FirstOrDefault(x => x.Id == menuItemId);
            if (menuItem == null)
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            if (shoppingCart == null && updateQuantityBy > 0)
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
                    Quantity = updateQuantityBy,
                    ShoppingCartId = newCart.Id,
                    MenuItem = null
                };
                _db.CartItems.Add(newCartItem);
                _db.SaveChanges();
            }
            else if (shoppingCart != null)
            {
                //check exist
                CartItem existCartItem = _db.CartItems.FirstOrDefault(x => x.ShoppingCartId == shoppingCart.Id && x.MenuItemId == menuItemId);

                if (existCartItem == null && updateQuantityBy > 0)
                {
                    CartItem newCartItem = new CartItem
                    {
                        MenuItemId = menuItemId,
                        Quantity = updateQuantityBy,
                        ShoppingCartId = shoppingCart.Id,
                        MenuItem = null
                    };
                    _db.CartItems.Add(newCartItem);
                    _db.SaveChanges();
                }
                else
                {
                    if((existCartItem.Quantity + updateQuantityBy == 0) || updateQuantityBy == 0)
                    {
                        _db.CartItems.Remove(existCartItem);
                        _db.SaveChanges();
                    }
                    else
                    {
                        existCartItem.Quantity += updateQuantityBy;
                        _db.CartItems.Update(existCartItem);
                        _db.SaveChanges();
                    }
                }
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

                if (shoppingCart?.CartItems?.Count > 0)
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
