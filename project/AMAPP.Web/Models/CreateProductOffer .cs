namespace AMAPP.Web.Models
{
    public class CreateProductOffer
    {
        public int ProductId { get; set; }
        public int PeriodSubscriptionId { get; set; }
        public List<DateTime> SelectedDeliveryDates { get; set; } = new List<DateTime>();
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentMode PaymentMode { get; set; }
    }
}
