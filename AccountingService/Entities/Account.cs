using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingService.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string Balance { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Account()
        {
        }

        public Account(string customerId, string initialCredit) 
        { 
            CustomerId = customerId;
            Balance = initialCredit;
            CreatedDate = DateTime.Now;
        }
    }
}
