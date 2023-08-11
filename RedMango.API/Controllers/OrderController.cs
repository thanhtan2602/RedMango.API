using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedMango.API.Data;
using RedMango.API.Models;
using RedMango.API.Models.Dto;
using RedMango.API.Utilities;

namespace RedMango.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ApiResponse _response;
        public OrderController(AppDbContext db)
        {
            _db = db;
            _response = new ApiResponse();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetOrders(string userId)
        {
            try
            {
                var orderHeaders = _db.OrderHeaders.Include(x => x.OrderDetails)
                    .ThenInclude(x => x.MenuItem)
                    .OrderByDescending(x => x.OrderHeaderId);

                if (!string.IsNullOrEmpty(userId))
                {
                    _response.Result = orderHeaders.Where(x => x.ApplicationUserId == userId).ToList();
                }
                else
                {
                    _response.Result = orderHeaders;
                }

                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.ErrorMessages.Add(ex.Message);
                _response.IsSuccess = false;
            }

            return _response;
        }

        [HttpGet("{id: int}")]
        public async Task<ActionResult<ApiResponse>> GetOrder(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var orderHeader = _db.OrderHeaders.Include(x => x.OrderDetails)
                    .ThenInclude(x => x.MenuItem)
                    .Where(x => x.OrderHeaderId == id);

                if (orderHeader == null)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = orderHeader;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.ErrorMessages.Add(ex.Message);
                _response.IsSuccess = false;
            }

            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateOrder([FromBody] OrderHeaderCreateDTO orderHeaderCreate)
        {
            try
            {
                OrderHeader order = new OrderHeader
                {
                    ApplicationUserId = orderHeaderCreate.ApplicationUserId,
                    PickupEmail = orderHeaderCreate.PickupEmail,
                    PickupName = orderHeaderCreate.PickupName,
                    PickupPhoneNumber = orderHeaderCreate.PickupPhoneNumber,
                    OrderTotal = orderHeaderCreate.OrderTotal,
                    OrderDate = DateTime.Now,
                    StripePaymentIntentId = orderHeaderCreate.StripePaymentIntentId,
                    TotalItems = orderHeaderCreate.TotalItems,
                    Status = string.IsNullOrEmpty(orderHeaderCreate.Status) ? SD.status_pending : orderHeaderCreate.Status
                };

                if (ModelState.IsValid)
                {
                    _db.OrderHeaders.Add(order);
                    _db.SaveChanges();
                    foreach (var item in orderHeaderCreate.OrderDetailsDTO)
                    {
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderHeaderId = order.OrderHeaderId,
                            ItemName = item.ItemName,
                            MenuItemId = item.MenuItemId,
                            Price = item.Price,
                            Quanlity = item.Quanlity,
                        };
                        _db.OrderDetails.Add(orderDetail);
                    }
                    _db.SaveChanges();
                    _response.Result = order;
                    order.OrderDetails = null;
                    _response.StatusCode = System.Net.HttpStatusCode.Created;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {

                _response.ErrorMessages.Add(ex.Message);
                _response.IsSuccess = false;
            }

            return _response;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> CreateOrder(int id, [FromBody] OrderHeaderUpdateDTO orderHeaderUpdate)
        {
            try
            {
                if (orderHeaderUpdate == null || id != orderHeaderUpdate.OrderHeaderId)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                OrderHeader orderFromDb = _db.OrderHeaders.FirstOrDefault(x => x.OrderHeaderId == id);
                if (orderFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                orderFromDb.PickupEmail = orderHeaderUpdate.PickupEmail;
                orderFromDb.PickupName = orderHeaderUpdate.PickupName;
                orderFromDb.PickupPhoneNumber = orderHeaderUpdate.PickupPhoneNumber;
                orderFromDb.StripePaymentIntentId = orderHeaderUpdate.StripePaymentIntentId;
                orderFromDb.Status = string.IsNullOrEmpty(orderHeaderUpdate.Status) ? SD.status_pending : orderHeaderUpdate.Status;

                _db.SaveChanges();
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.ErrorMessages.Add(ex.Message);
                _response.IsSuccess = false;
            }

            return _response;
        }
    }
}
