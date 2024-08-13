using InventoryManager.DataContext;
using InventoryManager.Entities;
using InventoryManager.IRepos;
using InventoryManager.IServices;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Repos
{
    public class PurchasesRepo : IPurchasesRepo
    {
        private readonly InventoryDbContext _inventoryDbContext;
        public PurchasesRepo(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }
        public async Task<Purchase> CreatePurchase(Purchase purchase)
        {
            try
            {
                var res =  _inventoryDbContext.Purchases.Add(purchase);
                await _inventoryDbContext.SaveChangesAsync();
                return res.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Supplier> CreateSupplier(Supplier supplier)
        {
            try
            {
                var res = _inventoryDbContext.Supplier.Add(supplier);
                await _inventoryDbContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeletePurchase(int Id)
        {
            try
            {
                string message = "";
                var purchase = _inventoryDbContext.Purchases.Where(x => x.Id == Id).FirstOrDefault();

                if (purchase == null)
                {
                    message = "Requested ID not available";
                    return message;
                }

                _inventoryDbContext.Purchases.Remove(purchase);
                await _inventoryDbContext.SaveChangesAsync();
                message = "Succesfully Deleted ";
                return message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Supplier>> GetAllSupplier()
        {
            try
            {
                var res = await _inventoryDbContext.Supplier.ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<Purchase> GetPurchaseById(int Id)
        {
            try
            {
                var res = _inventoryDbContext.Purchases.Where(x => x.Id == Id).FirstOrDefault();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Purchase>> GetPurchases(string searchText, int pageNumber, int pageCount)
        {
            try
            {
                IQueryable<Purchase> query =  _inventoryDbContext.Purchases;

                var res = await query.Where(x => (searchText == "" || (x.Supplier.Name.Contains(searchText)))).Include(xx=>xx.Product).Include(cc=>cc.Supplier).ToListAsync();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Purchase> Update(Purchase purchase)
        {
            try
            {
                var res = _inventoryDbContext.Purchases.Update(purchase);
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
