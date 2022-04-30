using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;

namespace HighGradeInventory.API.Models.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        public Task<Result<Inventory>> AddAsync(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Inventory>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Inventory>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}