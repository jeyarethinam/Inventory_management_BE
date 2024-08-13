using InventoryManager.Entities;
using InventoryManager.Models.RequestModels;

namespace InventoryManager.IServices
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);

        Task<List<Product>> GetProducts(string searchText, int? pageNumber = null, int? pageCount = null);
        Task<Product> GetProductById(int Id);
        Task<string> DeleteProduct(int Id);
        Task<Product> UpdateReceivedInventory(UpdateReceivedInventory updateReceivedInventory);
        Task<Product> UpdateOrderQty(UpdateOrderQty updateOrderQty);

    }
}
