namespace Microservices.MarketPlace.Example.Web.Models.Baskets
{
    public class BasketItemViewModel
    {
        public int Quantity { get; set; } = 1;

        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        private decimal? DiscountAppliedPrice;

        /// <summary>
        /// İndirim durumu olup olmadıgı kontrol edilerek fiyat bilgisi alınmaktadır.
        /// </summary>
        public decimal GetCurrentPrice
        {
            get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value * Quantity : Price * Quantity;
        }

        public void AppliedDiscount(decimal discountPrice)
        {
            DiscountAppliedPrice = discountPrice;
        }
    }
}
