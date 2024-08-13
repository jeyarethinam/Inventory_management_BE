using InventoryManager.Entities;
using InventoryManager.Models.RequestModels;

namespace InventoryManager.IServices
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(OrderRequestModel orderRequest);
        Task<List<Order>> GetOrders(string searchText, int? pageNumber = null, int? pageCount = null);
        Task<Order> GetOrderById(int Id);
        Task<string> DeleteOrder(int Id);
    }
}
