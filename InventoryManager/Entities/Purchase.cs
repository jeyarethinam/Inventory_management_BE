using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.Entities
{
    public class Purchase
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Supplier Supplier { get; set; }
        public Product Product { get; set; }


    }
}
