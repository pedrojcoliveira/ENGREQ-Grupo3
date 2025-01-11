namespace AMAPP.Web.Models
{
    public class CreateProductOffer
    {
        public int ProductId { get; set; }
        public int SubscriptionPeriodId { get; set; }
        public List<int> SelectedDeliveryDates { get; set; } = new List<int>();
        public List<string> PaymentMethod { get; set; } = new List<string>();
        public List<string> PaymentMode { get; set; } = new List<string>();
    }
}
