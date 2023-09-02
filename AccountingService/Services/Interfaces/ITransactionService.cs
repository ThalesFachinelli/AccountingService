namespace AccountingService.Services.Interfaces
{
    public interface ITransactionService
    {
        public void registerTransaction(string customerId, string value);
    }
}
