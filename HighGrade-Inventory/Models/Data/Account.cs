using System.ComponentModel.DataAnnotations.Schema;

namespace HighGradeInventory.API.Models.Data
{
    public class Account
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        [NotMapped]
        public string? Token { get; set; }
    }
}