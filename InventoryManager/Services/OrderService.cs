using InventoryManager.Entities;
using InventoryManager.IRepos;
using InventoryManager.IServices;
using InventoryManager.Models.RequestModels;
using InventoryManager.Repos;

namespace InventoryManager.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IProductService _productService;
        public OrderService(IOrderRepo orderRepo, IProductService productService)
        {
            _orderRepo = orderRepo;
            _productService = productService;

        }
        public async Task<Order> CreateOrder(OrderRequestModel orderRequest)
        {
            Order order = new Order();
            order.OrderDate = orderRequest.OrderDate;
            order.CustomerFirstName = orderRequest.CustomerFirstName;
            order.CustomerLastName = orderRequest.CustomerLastName;
            order.Quantity = orderRequest.Quantity;
            order.ProductId = orderRequest.ProductId;


            var product = await _productService.GetProductById(orderRequest.ProductId);
            if(product != null)
            {
                if (product.InventoryOnHand < orderRequest.Quantity)
                {
                    throw new Exception("Order cannot be creted more than hands on Quntity");
                }
            }
            var res = await _orderRepo.CreateOrder(order);

            if (res != null)
            {
                UpdateOrderQty updateOrderQty = new UpdateOrderQty();
                updateOrderQty.ProductId = res.ProductId;
                updateOrderQty.OrderQty = res.Quantity;
                var productRes = await _productService.UpdateOrderQty(updateOrderQty);
                if (productRes != null)
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

          


        }

        public async Task<string> DeleteOrder(int Id)
        {
            var res = await _orderRepo.DeleteOrder(Id);
            return res;
        }

        public async Task<Order> GetOrderById(int Id)
        {
            var res = await _orderRepo.GetOrderById(Id);
            return res;
        }

        public async Task<List<Order>> GetOrders(string searchText, int? pageNumber = null, int? pageCount = null)
        {
            if (pageNumber == null) pageNumber = 1;
            if (pageCount == null) pageCount = 25;

            var res = await _orderRepo.GetOrders(searchText, (int)pageNumber, (int)pageCount);

            return res;
        }
    }
}
