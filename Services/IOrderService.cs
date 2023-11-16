using EcommAPI.Entities;

namespace EcommAPI.Services
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
        Order GetOrder(Guid orderId);
        List<Order> GetOrdersByUser(string userId); //get orders by user
        List<Order> GetOrders(); //return all the orders
    }
}
