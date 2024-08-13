namespace InventoryManager.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public string Lable { get; set; }
        public int StartingInventory { get; set; }
        public int InventoryReceived { get; set;}
        public int InventoryOnHand { get; set; }
        public int MinimumRequired { get; set; }
        public DateTime ModifiedOn { get; set; }


    }
}
