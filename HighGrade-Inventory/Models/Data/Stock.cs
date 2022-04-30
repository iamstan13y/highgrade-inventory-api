using System.ComponentModel.DataAnnotations.Schema;

namespace HighGradeInventory.API.Models.Data
{
    public class Stock
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public double Quantity { get; set; }
        [ForeignKey("InventoryId")]
        public Inventory? Inventory { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}