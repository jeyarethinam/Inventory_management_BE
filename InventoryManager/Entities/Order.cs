using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public Product Product { get; set; }
    }
}
