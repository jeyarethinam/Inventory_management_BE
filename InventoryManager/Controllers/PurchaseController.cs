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
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchasesService _puchasesService;
        public PurchaseController(IPurchasesService puchasesService)
        {
            _puchasesService= puchasesService;
        }
        [HttpPost]
        public async Task<ActionResult> CreatePurchase(PurchaseRequestModel purchase)
        {
            var res = await _puchasesService.CreatePurchase(purchase);
            return Ok(res);
        }


        [HttpGet("search")]
        public async Task<ActionResult> GetPurchasesSearch(string searchString = "", int? pageNumber = null, int? pageCount = null)
        {
            var res = await _puchasesService.GetPurchases(searchString, pageNumber, pageCount);
            return Ok(res);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetPurschaseById(int id)
        {
            string message = "";
            if (id == null)
            {
                message = "Id Cannot be null";
                return BadRequest(message);
            }

            var res = await _puchasesService.GetPurchaseById(id);
            if (res == null)
            {
                message = "Purchase not found ";
                return NotFound(message);

            }
            return Ok(res);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePurchase(int id)
        {

            string message = "";
            if (id == null)
            {
                message = "Id Cannot be null";
                return BadRequest(message);
            }

            var res = await _puchasesService.GetPurchaseById(id);
            if (res == null)
            {
                message = "Purchase not found ";
                return NotFound(message);

            }
            await _puchasesService.DeletePurchase(id);
            message = "Deleted Suceesfully";

            return Ok(message);
        }

        [HttpPost("CreateSupplier")]
        public async Task<ActionResult> CreateSupplier(Supplier supplier)
        {
            var res = await _puchasesService.CreateSupplier(supplier);
            return Ok(res);
        }

        [HttpGet("GetAllSupplier")]
        public async Task<ActionResult> GetAllSuppliers()
        {
            var res = await _puchasesService.GetAllSupplier();
            return Ok(res);
        }
    }
}
