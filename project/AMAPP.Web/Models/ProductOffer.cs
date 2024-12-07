namespace AMAPP.Web.Models
{
    public class ProductOffer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int PeriodSubscriptionId { get; set; }
        public string SubscriptionPeriodName { get; set; }
        public List<DateTime> SelectedDeliveryDates { get; set; } = new List<DateTime>();
    }

}
