using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;

namespace HighGradeInventory.API.Models.Repository
{
    public interface IInventoryRepository
    {
        Task<Result<IEnumerable<Inventory>>> GetAllAsync();
        Task<Result<Inventory>> GetByIdAsync(int id);
        Task<Result<Inventory>> AddAsync(Inventory inventory);
    }
}