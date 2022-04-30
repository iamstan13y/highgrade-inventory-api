using HighGradeInventory.API.Models.Data;

namespace HighGradeInventory.API.Services
{
    public interface IJwtService
    {
        Task<string> GenerateToken(Account account);
    }
}