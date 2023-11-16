using EcommAPI.Entities;

namespace EcommAPI.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductsByPrice(double price); 
        Product GetProductById(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
