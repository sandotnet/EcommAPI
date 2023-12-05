namespace EcommAPI.DTOs
{
    public class UserOrderProduct
    {
        public UserOrderProduct(string? userName, string? productName, DateTime orderDate)
        {
            UserName = userName;
            ProductName = productName;
            OrderDate = orderDate;
        }

        public string? UserName { get; set; }
        public string? ProductName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
