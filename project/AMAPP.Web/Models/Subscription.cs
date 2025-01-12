namespace AMAPP.Web.Models
{
    public class Subscription
    {
        // Propriedades para Listagem
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProductOfferId { get; set; }
        public int SubscriptionId { get; set; }
        public int Quantity { get; set; }
        public int SubscriptionPeriodId { get; set; }
        public List<int> SelectedDeliveryDates { get; set; } = new List<int>();

    }
}
