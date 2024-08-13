using InventoryManager.Entities;

namespace InventoryManager.IRepos
{
    public interface IOrderRepo
    {
        Task<Order> CreateOrder(Order order);
        Task<List<Order>> GetOrders(string searchText, int pageNumber, int pageCount);
        Task<Order> GetOrderById(int Id);
        Task<string> DeleteOrder(int Id);

        Task<Order> Update(Order order);
    }
}
