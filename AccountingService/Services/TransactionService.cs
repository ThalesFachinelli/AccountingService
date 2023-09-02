using AccountingService.DataContext;
using AccountingService.Services.Interfaces;

namespace AccountingService.Services
{
    public class TransactionService : ITransactionService

    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void registerTransaction(string customerId, string value) 
        {
            try
            {
                _context.Transactions.Add(new Entities.Transaction(customerId, value));
            }
            catch (Exception e) 
            {
                throw e;
            }
        }
    }
}
