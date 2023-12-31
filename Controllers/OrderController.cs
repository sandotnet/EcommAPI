﻿using EcommAPI.Entities;
using EcommAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;

        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        //public OrderController()
        //{
        //    orderService = new OrderService();
        //}
        //POST /PlaceOrder
        [HttpPost,Route("PlaceOrder")]
        [Authorize(Roles = "Customer")]
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
        [Authorize(Roles = "Customer")]
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
        [Authorize(Roles = "Admin")]
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
