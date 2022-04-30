using HighGradeInventory.API.Models.Local;
using HighGradeInventory.API.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighGradeInventory.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post(LoginRequest request)
        {
            var result = await _accountRepository.LoginAsync(request);

            if (!result.Success) return Unauthorized(result);
            return Ok(result);
        }
    }
}