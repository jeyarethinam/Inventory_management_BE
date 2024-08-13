using InventoryManager.DataContext;
using InventoryManager.Entities;
using InventoryManager.IRepos;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly InventoryDbContext _inventoryDbContext;
        public OrderRepo(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                var res = _inventoryDbContext.Order.Add(order);
                await _inventoryDbContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteOrder(int Id)
        {
            try
            {
                string message = "";
                var order = _inventoryDbContext.Order.Where(x => x.Id == Id).FirstOrDefault();

                if (order == null)
                {
                    message = "Requested ID not available";
                    return message;
                }

                _inventoryDbContext.Order.Remove(order);
                await _inventoryDbContext.SaveChangesAsync();
                message = "Succesfully Deleted ";
                return message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Order> GetOrderById(int Id)
        {
            try
            {
                var res = _inventoryDbContext.Order.Where(x => x.Id == Id).FirstOrDefault();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Order>> GetOrders(string searchText, int pageNumber, int pageCount)
        {
            try
            {
                IQueryable<Order> query = _inventoryDbContext.Order;

                var res = query.Where(x => (searchText == "" || (x.CustomerFirstName.Contains(searchText))) && (searchText == "" || (x.CustomerLastName.Contains(searchText)))).Include(xx => xx.Product).ToList();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Order> Update(Order order)
        {

            try
            {
                var res = _inventoryDbContext.Order.Update(order);
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
