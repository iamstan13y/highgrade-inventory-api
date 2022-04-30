using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;

namespace HighGradeInventory.API.Models.Repository
{
    public interface IAccountRepository
    {
        Task<Result<Account>> CreateAsync(Account account);
        Task<Result<Account>> LoginAsync(LoginRequest login);
    }
}