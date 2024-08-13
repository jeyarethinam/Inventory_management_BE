using InventoryManager.Entities;

namespace InventoryManager.IRepos
{
    public interface IPurchasesRepo
    {
        Task<Purchase> CreatePurchase(Purchase purchase);
        Task<List<Purchase>> GetPurchases(string searchText, int pageNumber, int pageCount);
        Task<Purchase> GetPurchaseById(int Id);
        Task<string> DeletePurchase(int Id);

        Task<Purchase> Update(Purchase purchase);
        Task<Supplier> CreateSupplier(Supplier supplier);
        Task<List<Supplier>> GetAllSupplier();

    }
}
