using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.Models.RequestModels
{
    public class OrderRequestModel
    {
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}
