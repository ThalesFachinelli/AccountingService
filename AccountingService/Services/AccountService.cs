using AccountingService.DataContext;
using AccountingService.Entities;
using AccountingService.Exceptions;
using AccountingService.Models;
using AccountingService.Services.Interfaces;
using System.Security.Principal;

namespace AccountingService.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private ITransactionService _transactionService;

        public AccountService(ApplicationDbContext context, ITransactionService transactionService) {
            _context = context;
            _transactionService = transactionService;
        }
        public Account createAccount(CreateAccountRequest createAccountRequest) 
        {
            try 
            {
                validateCreateAccountRequest(createAccountRequest);
                var account = new Account(createAccountRequest.customerId, createAccountRequest.initialCredit);
                _context.Accounts.Add(account);
                if (Double.Parse(createAccountRequest.initialCredit) > 0) 
                {
                    _transactionService.registerTransaction(createAccountRequest.customerId, createAccountRequest.initialCredit);
                }
                _context.SaveChanges();
                return account;
            }
            catch(Exception e) 
            {
                throw e;
            }
        }

        private void validateCreateAccountRequest(CreateAccountRequest createAccountRequest) 
        {
            if (createAccountRequest == null || createAccountRequest.customerId == null || createAccountRequest.initialCredit == null)
            {
                throw new BadHttpRequestException("Invalid request body");
            }
            else if (!IsDoubleRealNumber(createAccountRequest.initialCredit))
            {
                throw new InitialCreditNaNException("Initial credit value has to be a number in Double format");
            }
            else if (Double.Parse(createAccountRequest.initialCredit) < 0)
            {
                throw new NegativeInitialCreditException("Initial credit value cannot be lesser than zero");
            }
            else if (findByCustomerId(createAccountRequest.customerId) != null)
            {
                throw new CustomerAccountAlreadyExistException("Customer already has an account");
            }
        }

        private static bool IsDoubleRealNumber(string value)
        {
            if (double.TryParse(value, out double d) && !Double.IsNaN(d) && !Double.IsInfinity(d))
            {
                return true;
            }

            return false;
        }

        private Account? findByCustomerId(string customerId)
        {
            var result = _context.Accounts
                       .Where(a => a.CustomerId == customerId)
                       .Select(a => a);

            if (result.ToList().Count > 0) 
            {
                return result.First();
            }
            else 
            { 
                return null; 
            }  
        }

        public List<Account> getAccounts() 
        {
            return _context.Accounts.ToList();
        }
    }
}
