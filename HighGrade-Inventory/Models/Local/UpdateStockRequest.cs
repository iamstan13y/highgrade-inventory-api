namespace HighGradeInventory.API.Models.Local
{
    public class UpdateStockRequest
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public double Quantity { get; set; }
    }
}