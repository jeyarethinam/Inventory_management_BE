using InventoryManager.Entities;
using InventoryManager.IServices;
using InventoryManager.Models.RequestModels;
using InventoryManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(OrderRequestModel orderRequest)
        {
            var res = await _orderService.CreateOrder(orderRequest);
            return Ok(res);
        }
        [HttpGet("search")]
        public async Task<ActionResult> GetOrders(string searchString = "", int? pageNumber = null, int? pageCount = null)
        {
            var res = await _orderService.GetOrders(searchString, pageNumber, pageCount);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrdersById(int id)
        {
            string message = "";
            if (id == null)
            {
                message = "Id Cannot be null";
                return BadRequest(message);
            }

            var res = await _orderService.GetOrderById(id);
            if (res == null)
            {
                message = "Purchase not found ";
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

            var res = await _orderService.GetOrderById(id);
            if (res == null)
            {
                message = "Product not found ";
                return NotFound(message);

            }
            await _orderService.DeleteOrder(id);
            message = "Deleted Suceesfully";

            return Ok(message);
        }
    }
}
