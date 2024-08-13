using InventoryManager.Entities;
using InventoryManager.Models.RequestModels;

namespace InventoryManager.IServices
{
    public interface IPurchasesService
    {
        Task<Purchase> CreatePurchase(PurchaseRequestModel purchaseRequestModel);
        Task<Purchase> GetPurchaseById(int Id);
        Task<string> DeletePurchase(int Id);
        Task<List<Purchase>> GetPurchases(string searchText, int? pageNumber = null, int? pageCount = null);
        Task<Supplier> CreateSupplier(Supplier supplier);
        Task<List<Supplier>> GetAllSupplier();


    }
}
