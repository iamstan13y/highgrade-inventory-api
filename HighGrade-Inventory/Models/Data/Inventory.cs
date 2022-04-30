namespace HighGradeInventory.API.Models.Data
{
    public class Inventory
    {
        public int Id { get; set; }
        public string? ColourName { get; set; }
        public double Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}