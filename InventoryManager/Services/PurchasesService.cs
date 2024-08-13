using InventoryManager.Entities;
using InventoryManager.IRepos;
using InventoryManager.IServices;
using InventoryManager.Models.RequestModels;
using InventoryManager.Repos;

namespace InventoryManager.Services
{
    public class PurchasesService : IPurchasesService
    {
        private readonly IPurchasesRepo _purchasesRepo;
        private readonly IProductService _productService;
        public PurchasesService(IPurchasesRepo purchasesRepo, IProductService productService)
        {
            _purchasesRepo = purchasesRepo;
            _productService = productService;

        }
        public async Task<Purchase> CreatePurchase(PurchaseRequestModel purchaseRequestModel)
        {
            Purchase purchase = new Purchase();
            purchase.ProductId = purchaseRequestModel.ProductId;
            purchase.Quantity = purchaseRequestModel.Quantity;
            purchase.SupplierId = purchaseRequestModel.SupplierId;
            purchase.PurchaseDate = purchaseRequestModel.PurchaseDate;

            var res = await _purchasesRepo.CreatePurchase(purchase);
            if (res != null)
            {
                UpdateReceivedInventory updateReceivedInventory = new UpdateReceivedInventory();
                updateReceivedInventory.ProductId = res.ProductId;
                updateReceivedInventory.ReceivedQuntity = res.Quantity;

                var updatedRes = await _productService.UpdateReceivedInventory(updateReceivedInventory);
                if (updatedRes!=null)
                {
                    return res;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

           


        }

        public async Task<Supplier> CreateSupplier(Supplier supplier)
        {
           var res = await _purchasesRepo.CreateSupplier(supplier);
            return res;
        }

        public async Task<string> DeletePurchase(int Id)
        {
            var res = await _purchasesRepo.DeletePurchase(Id);
            return res;
        }

        public async Task<List<Supplier>> GetAllSupplier()
        {
           var res = await _purchasesRepo.GetAllSupplier();
            return res;
        }

        public async Task<Purchase> GetPurchaseById(int Id)
        {
            var res = await _purchasesRepo.GetPurchaseById(Id);
            return res;
        }

        public async Task<List<Purchase>> GetPurchases(string searchText, int? pageNumber = null, int? pageCount = null)
        {
            if (pageNumber == null) pageNumber = 1;
            if (pageCount == null) pageCount = 25;

            var res = await _purchasesRepo.GetPurchases(searchText, (int)pageNumber, (int)pageCount);

            return res;
        }
    }
}
