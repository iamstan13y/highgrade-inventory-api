using HighGradeInventory.API.Models.Data;
using HighGradeInventory.API.Models.Local;
using HighGradeInventory.API.Services;

namespace HighGradeInventory.API.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;

        public AccountRepository(AppDbContext context, IPasswordService passwordService, IJwtService jwtService)
        {
            _context = context;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        public async Task<Result<Account>> CreateAsync(Account account)
        {
            await _context.Accounts!.AddAsync(account);
            await _context.SaveChangesAsync();

            return new Result<Account>(account);
        }

        public async Task<Result<Account>> LoginAsync(LoginRequest login)
        {
            var account = await _context.Accounts!.Where(x => x.Email == login.Email).FirstOrDefaultAsync();

            if (account == null || _passwordService.VerifyHash(login.Password!, account!.Password!) == false)
                return new Result<Account>(false, new List<string>() { "Username or password is incorrect!" });

            account.Token = await _jwtService.GenerateToken(account);
            account.Password = "*************";

            return new Result<Account>(account);
        }
    }
}