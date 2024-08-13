using InventoryManager.DataContext;
using InventoryManager.Entities;
using InventoryManager.IRepos;
using InventoryManager.Models.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly InventoryDbContext _inventoryDbContext;
        public ProductRepo(InventoryDbContext inventoryDbContext)
        {

            _inventoryDbContext = inventoryDbContext;

        }
        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                var res = _inventoryDbContext.Products.Add(product);
                await _inventoryDbContext.SaveChangesAsync();
                return res.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteProduct(int Id)
        {
            try
            {
                string message = "";
                var product = _inventoryDbContext.Products.Where(x => x.Id == Id).FirstOrDefault();

                if (product == null)
                {
                    message = "Requested ID not available";
                    return message;
                }

                _inventoryDbContext.Products.Remove(product);
                await _inventoryDbContext.SaveChangesAsync();
                message = "Succesfully Deleted ";
                return message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           


        }

        public async Task<Product> GetProductById(int Id)
        {
            try
            {
                var res = _inventoryDbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Product>> GetProducts(string searchText, int pageNumber, int pageCount)
        {
            try
            {
                IQueryable<Product> query = _inventoryDbContext.Products;

                // var res = query.Where(x => (searchText == "" || (x.Name.Contains(searchText)) || (searchText == "" || x.PartNumber.Contains(searchText) )|| (searchText == "" || x.Lable.Contains(searchText)))).Skip(pageNumber).Take(pageCount).ToList();
                var res = query.Where(x => (searchText == "" || (x.Name.Contains(searchText)) || (searchText == "" || x.PartNumber.Contains(searchText)) || (searchText == "" || x.Lable.Contains(searchText)))).ToList();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Product> Update(Product product)
        {
            try
            {
                var res = _inventoryDbContext.Products.Update(product);
                await _inventoryDbContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
