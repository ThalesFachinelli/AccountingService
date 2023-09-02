namespace AccountingService.Exceptions
{
    public class NegativeInitialCreditException : Exception
    {
        public NegativeInitialCreditException()
        {
        }

        public NegativeInitialCreditException(string message)
            : base(message)
        {
        }

        public NegativeInitialCreditException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
