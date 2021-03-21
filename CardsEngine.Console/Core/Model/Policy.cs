using CardsEngine.Console.Core.Enums;

namespace CardsEngine.Console.Core.Model
{
    public class Policy
    {
        public string Brand { get; set; }
        public decimal Amount { get; set; }
        public DeferPaymentType DeferPayment { get; set; }
    }
}
