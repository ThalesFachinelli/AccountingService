namespace AccountingService.Exceptions
{
    public class InitialCreditNaNException : Exception
    {
        public InitialCreditNaNException()
        {
        }

        public InitialCreditNaNException(string message)
            : base(message)
        {
        }

        public InitialCreditNaNException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
