using EcommAPI.Database;
using EcommAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EcommAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderProductController: ControllerBase
    {
        private readonly MyContext _context;

        public UserOrderProductController(MyContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var result = from p in _context.Products
        //                 join o in _context.Orders
        //                 on p.ProductId equals o.ProductId
        //                 join u in _context.Users on o.UserId equals u.UserId
        //                 select new UserOrderProduct(u.Name, p.Name, o.OrderDate);
        //    return Ok(result);


        //}
        [HttpGet]
        public IActionResult Get(string uname)
        {
            var result = from p in _context.Products
                         join o in _context.Orders
                         on p.ProductId equals o.ProductId
                         join u in _context.Users on o.UserId equals u.UserId
                         where u.Name == uname
                         select new UserOrderProduct(u.Name, p.Name, o.OrderDate);
            return Ok(result);
                       
                       
        }
    }
}
