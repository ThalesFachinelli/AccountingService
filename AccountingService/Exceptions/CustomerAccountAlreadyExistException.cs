namespace AccountingService.Exceptions
{
    public class CustomerAccountAlreadyExistException : Exception
    {
        public CustomerAccountAlreadyExistException()
        {
        }

        public CustomerAccountAlreadyExistException(string message)
            : base(message)
        {
        }

        public CustomerAccountAlreadyExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
