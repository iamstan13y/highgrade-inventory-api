namespace HighGradeInventory.API.Models.Local
{
    public class StockRequest
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public double Quantity { get; set; }
    }
}