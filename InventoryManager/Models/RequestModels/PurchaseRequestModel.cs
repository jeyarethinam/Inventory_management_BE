using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.Models.RequestModels
{
    public class PurchaseRequestModel
    {
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
    }
}
