using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;

namespace HighGradeInventory.API.Models.Repository
{
    public interface IStockRepository
    {
        Task<Result<IEnumerable<Stock>>> GetAllAsync();
        Task<Result<Stock>> GetByIdAsync(int id);
        Task<Result<Stock>> AddAsync(Stock stock);
        Task<Result<Stock>> UpdateAsync(Stock stock);
    }
}