using Newtonsoft.Json;

namespace AccountingService.Models
{
    public class CreateAccountRequest
    {
        [JsonProperty("customer_id")]
        public String customerId { get; set; }

        [JsonProperty("initial_credit")]
        public String initialCredit { get; set; }
    }
}
