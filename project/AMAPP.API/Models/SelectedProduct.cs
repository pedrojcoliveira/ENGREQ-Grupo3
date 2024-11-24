namespace AMAPP.API.Models
{
    public class SelectedProduct
    {
        public int Id { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public int Quantity { get; set; }
    }
}
