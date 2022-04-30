using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;
using Microsoft.EntityFrameworkCore;

namespace HighGradeInventory.API.Models.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Inventory>> AddAsync(Inventory inventory)
        {
            inventory.DateCreated = DateTime.Now;
            inventory.DateModified = DateTime.Now;

            await _context.AddAsync(inventory);
            await _context.SaveChangesAsync();

            return new Result<Inventory>(inventory);
        }

        public async Task<Result<IEnumerable<Inventory>>> GetAllAsync()
        {
            var inventories = await _context.Inventories!.ToListAsync();
            return new Result<IEnumerable<Inventory>>(inventories);
        }

        public async Task<Result<Inventory>> GetByIdAsync(int id)
        {
            var inventory = await _context.Inventories!.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (inventory == null) return new Result<Inventory>(false, new List<string> { "Inventory does not exist." });
            return new Result<Inventory>(inventory);
        }
    }
}