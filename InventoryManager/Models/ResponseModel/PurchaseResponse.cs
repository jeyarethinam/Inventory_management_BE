using InventoryManager.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.Models.ResponseModel
{
    public class PurchaseResponse
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }

        public int SupplierId { get; set; }

       
        public int ProductId { get; set; }

       public string ProductName { get; set; }
        public string SupplierName { get; set; }
    }
}
