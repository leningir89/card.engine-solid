namespace CardsEngine.Console.DataContext.Models
{
    public class CardSettingByBrands
    {
        public int CardSettingByBrandsID { get; set; }
        public decimal BaseCommission { get; set; }
        public decimal? PromotionCommission { get; set; }
        public string Brand { get; set; }
    }
}
