namespace AMAPP.Web.Models
{
    public class CreateSubscription
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SubscriptionId { get; set; }
        public int Quantity { get; set; }
        public int SubscriptionPeriodId { get; set; }
        public List<int> ProductOffer { get; set; } = new List<int>();
    }
}
