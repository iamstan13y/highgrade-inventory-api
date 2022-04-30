using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;
using Microsoft.EntityFrameworkCore;

namespace HighGradeInventory.API.Models.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<Stock>>> GetAllAsync()
        {
            var stock = await _context.Stocks!.ToListAsync();

            return new Result<IEnumerable<Stock>>(stock);
        }

        public async Task<Result<Stock>> GetByIdAsync(int id)
        {
            var stock = await _context.Stocks!.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (stock == null) return new Result<Stock>(false, new List<string> { "Stock does not exist." });

            return new Result<Stock>(stock);
        }
    }
}