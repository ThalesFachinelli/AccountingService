using AccountingService.Entities;
using AccountingService.Models;
using AccountingService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingService.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService) {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult GetAccounts() {
            return Ok(_accountService.getAccounts());
        }

        [HttpPost]
        public IActionResult createAccount([FromBody] CreateAccountRequest createAccountRequest) {
            return Ok(_accountService.createAccount(createAccountRequest));
        }
        
    }
}
