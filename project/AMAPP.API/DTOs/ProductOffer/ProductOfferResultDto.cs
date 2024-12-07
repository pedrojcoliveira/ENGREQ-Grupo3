namespace AMAPP.API.DTOs.ProductOffer
{
    public class ProductOfferResultDto
    {
       // public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int PeriodSubscriptionId { get; set; }
        public string SubscriptionPeriodName { get; set; }
        public List<DateTime> SelectedDeliveryDates { get; set; } = new List<DateTime>();

       // public Constants.PaymentMethod PaymentMethod { get; set; }
       // public Constants.PaymentMode PaymentMode { get; set; }
    }


}
