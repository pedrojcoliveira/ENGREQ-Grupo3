using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountBalanceController : ControllerBase
    {
        private readonly IAccountBalanceService _accountBalanceService;

        public AccountBalanceController(IAccountBalanceService accountBalanceService)
        {
            _accountBalanceService = accountBalanceService;
        }

        [HttpGet("CalculateCoproducerBalance")]
        public async Task<IActionResult> CalculateCoproducerBalance()
        {
            var coproducerbalance = await _accountBalanceService.SetAccountBalance();
            return Ok(coproducerbalance);
        }
    }
}
