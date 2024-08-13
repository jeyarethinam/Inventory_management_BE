namespace InventoryManager.Models.RequestModels
{
    public class UpdateOrderQty
    {
        public int ProductId { get; set; }
        public int OrderQty { get; set; }
    }
}
