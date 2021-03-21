namespace CardsEngine.Console.Core.Model
{
    public class CardSettings
    {
        public CardSettings(int commissionId, decimal baseCommission, decimal? promotionCommission)
        {
            CommissionId = commissionId;
            BaseCommission = baseCommission;
            PromotionCommission = promotionCommission;
        }

        public int CommissionId { get; set; }
        public decimal BaseCommission { get; set; } 
        public decimal? PromotionCommission { get; set; }
    }
}
