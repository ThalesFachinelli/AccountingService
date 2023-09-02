namespace AccountingService.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Transaction()
        {
        }

        public Transaction(string customerId, string value) 
        {
            CustomerId = customerId;
            Value = value;
            CreatedDate = DateTime.Now;
        }
    }
}
