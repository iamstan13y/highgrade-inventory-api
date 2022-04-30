namespace HighGradeInventory.API.Models.Local
{
    public class InventoryRequest
    {
        public string? ColourName { get; set; }
        public double Quantity { get; set; }
        public double AlertLevel { get; set; }
    }
}