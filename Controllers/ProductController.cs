using AutoMapper;
using EcommAPI.DTOs;
using EcommAPI.Entities;
using EcommAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            _mapper = mapper;
        }

        //public ProductController(IMapper mapper)
        //{
        //    productService = new ProductService();
        //    _mapper = mapper;
        //}
        //end points
        //GET /GetAllProducts
        [HttpGet,Route("GetAllProducts")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            try
            {
                List<Product> products=productService.GetProducts();
                List<ProductDto> productsDto = _mapper.Map<List<ProductDto>>(products); //converting enity to dto
                return StatusCode(200, productsDto); //here products details are sending in json format
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        //Get /GetProductById/1
        [HttpGet,Route("GetProductById/{productId}")]
        [Authorize] //all authenticated users can access
        public IActionResult Get(int productId)
        {
            try
            {
                Product product=productService.GetProductById(productId);
                ProductDto productDto=_mapper.Map<ProductDto>(product);
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
        [Authorize(Roles = "Admin")]
        [HttpPost,Route("AddProduct")]
        public IActionResult Add([FromBody] ProductDto productDto)
        {
            try
            {
                Product product=_mapper.Map<Product>(productDto); //converting entity from dto
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
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(ProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto); //converting entity from dto
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
        [Authorize(Roles = "Admin")]
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
