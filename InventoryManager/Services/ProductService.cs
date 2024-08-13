using InventoryManager.Entities;
using InventoryManager.IRepos;
using InventoryManager.IServices;
using InventoryManager.Models.RequestModels;

namespace InventoryManager.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            product.InventoryReceived = 0;
            product.ModifiedOn = DateTime.Now;
            product.InventoryOnHand = product.StartingInventory;
            var res = await _productRepo.CreateProduct(product);
            return res;

        }

        public async Task<string> DeleteProduct(int Id)
        {
            var res = await _productRepo.DeleteProduct(Id);
            return res;
        }

        public async Task<Product> GetProductById(int Id)
        {
            var res = await _productRepo.GetProductById(Id);
            return res;
        }

        public async Task<List<Product>> GetProducts(string searchText, int? pageNumber = null, int? pageCount = null)
        {
            if (pageNumber == null) pageNumber = 1;
            if (pageCount == null) pageCount = 25;

            var res = await _productRepo.GetProducts(searchText, (int)pageNumber, (int)pageCount);

            return res;
        }

        public async Task<Product> UpdateOrderQty(UpdateOrderQty updateOrderQty)
        {
            var product = await _productRepo.GetProductById(updateOrderQty.ProductId);
            if (product != null)
            {
                product.InventoryOnHand = product.InventoryOnHand - updateOrderQty.OrderQty;
                var res = await _productRepo.Update(product);
                return res;
            }
            else
            {
                return null;
            }
        }
        public async Task<Product> UpdateReceivedInventory(UpdateReceivedInventory updateReceivedInventory)
        {
            var product = await _productRepo.GetProductById(updateReceivedInventory.ProductId);
            if (product != null)
            {
                product.InventoryReceived = updateReceivedInventory.ReceivedQuntity;
                product.InventoryOnHand = product.InventoryOnHand + updateReceivedInventory.ReceivedQuntity;
                product.ModifiedOn = DateTime.Now;

                var res = await _productRepo.Update(product);
                return res;
            }
            else
            {
                return null;
            }
        }
    }
}
