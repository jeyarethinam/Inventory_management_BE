using InventoryManager.Entities;
using InventoryManager.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            var res = await _productService.CreateProduct(product);
            return Ok(res);
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetProductSearch(string searchString = "", int? pageNumber = null, int? pageCount = null)
        {
            var res = await _productService.GetProducts(searchString, pageNumber, pageCount);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            string message = "";
            if (id == null)
            {
                message = "Id Cannot be null";
                return BadRequest(message);
            }

            var res = await _productService.GetProductById(id);
            if (res == null)
            {
                message = "Product not found ";
                return NotFound(message);

            }
            return Ok(res);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {

            string message = "";
            if (id == null)
            {
                message = "Id Cannot be null";
                return BadRequest(message);
            }

            var res = await _productService.GetProductById(id);
            if (res == null)
            {
                message = "Product not found ";
                return NotFound(message);

            }
            await _productService.DeleteProduct(id);
            message = "Deleted Suceesfully";

            return Ok(message);
        }


    }
}
