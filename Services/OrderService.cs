using EcommAPI.Database;
using EcommAPI.Entities;

namespace EcommAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyContext _context;
        public OrderService()
        {
            _context = new MyContext();
        }

        public Order GetOrder(Guid orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public List<Order> GetOrdersByUser(string userId)
        {
            return _context.Orders.Where(o=>o.UserId == userId).ToList();
        }

        public void PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
