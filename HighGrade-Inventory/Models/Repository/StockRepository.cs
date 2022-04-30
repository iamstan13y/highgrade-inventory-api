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
    }
}