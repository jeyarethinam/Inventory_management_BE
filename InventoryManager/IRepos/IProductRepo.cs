using InventoryManager.Entities;
using InventoryManager.Models.RequestModels;

namespace InventoryManager.IRepos
{
    public interface IProductRepo
    {

        Task<Product> CreateProduct(Product product);
        Task<List<Product>> GetProducts(string searchText, int pageNumber,int pageCount);
        Task<Product> GetProductById(int Id);
        Task<string> DeleteProduct(int Id);
       
        Task<Product> Update(Product product);
    }
}
