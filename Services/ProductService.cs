using EcommAPI.Database;
using EcommAPI.Entities;

namespace EcommAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly MyContext _context;
        public ProductService()
        {
            _context = new MyContext();
        }
        public void AddProduct(Product product) //Add Product 
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                //Product product = _context.Products.Find(productId); //Find() use to serarch product using primary key value
                Product product = _context.Products.SingleOrDefault(p => p.ProductId == productId); //use SingleOrDefault() to serach product
                                                                                                    //using non primary key column
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProductById(int productId)
        {
            try
            {
                //Product product = _context.Products.Find(productId)
                Product product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _context.Products.ToList(); //ToList() return all products in the form of List
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetProductsByPrice(double price)
        {
            try
            {
                List<Product> products =
                _context.Products.Where(item => item.Price > price).ToList();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
