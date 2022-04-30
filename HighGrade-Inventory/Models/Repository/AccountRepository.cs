using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;

namespace HighGradeInventory.API.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Account>> CreateAsync(Account account)
        {
            await _context.Accounts!.AddAsync(account);
            await _context.SaveChangesAsync();

            return new Result<Account>(account);
        }
    }
}