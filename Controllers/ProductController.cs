using EcommAPI.Entities;
using EcommAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }
        //end points
        //GET /GetAllProducts
        [HttpGet,Route("GetAllProducts")]
        public IActionResult GetAll()
        {
            try
            {
                List<Product> products=productService.GetProducts();
                return StatusCode(200, products); //here products details are sending in json format
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //Get /GetProductById/1
        [HttpGet,Route("GetProductById/{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                Product product=productService.GetProductById(productId);
                if (product != null)
                    return StatusCode(200, product);
                else
                  return StatusCode(404, new JsonResult("Invalid Id")); //convert string to Json use JsonResult class
                //return StatusCode(404,product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //POST /AddProduct
        [HttpPost,Route("AddProduct")]
        public IActionResult Add([FromBody] Product product)
        {
            try
            {
                productService.AddProduct(product);
                return StatusCode(200, product); //after successfully add product we return same product in json form
                //return Ok(); //return emplty result
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //PUT /EditProduct
        [HttpPut,Route("EditProduct")]
        public IActionResult Edit(Product product)
        {
            try
            {
                productService.UpdateProduct(product);
                return StatusCode(200, product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //Delete /DeleteProduct/1
        [HttpDelete,Route("DeleteProduct/{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                productService.DeleteProduct(productId);
                return StatusCode(200, new JsonResult($"Product with Id {productId} is Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
