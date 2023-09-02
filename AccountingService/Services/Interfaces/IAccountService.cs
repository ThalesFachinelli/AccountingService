using AccountingService.Entities;
using AccountingService.Models;

namespace AccountingService.Services.Interfaces
{
    public interface IAccountService
    {
        public List<Account> getAccounts();
        public Account createAccount(CreateAccountRequest createAccountRequest);
    }
}
