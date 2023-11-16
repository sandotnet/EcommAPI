using EcommAPI.Entities;
using EcommAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;
        public OrderController()
        {
            orderService = new OrderService();
        }
        //POST /PlaceOrder
        [HttpPost,Route("PlaceOrder")]
        public IActionResult PlaceOrder(Order order)
        {
            try
            {
                order.OrderId= Guid.NewGuid(); //genereate new guid
                orderService.PlaceOrder(order);
                return StatusCode(200, order);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //Get /GetOrdersByUser
        [HttpGet,Route("GetOrdersByUser/{userId}")]
        public IActionResult GetOrdersByUser(string userId)
        {
            try
            {
               List<Order> orders=orderService.GetOrdersByUser(userId);
                return StatusCode(200, orders);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //Get //GetAllOrders
        [HttpGet,Route("GetOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                List<Order> orders = orderService.GetOrders();
                return StatusCode(200, orders);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
