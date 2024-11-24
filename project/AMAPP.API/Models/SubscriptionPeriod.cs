namespace AMAPP.API.Models
{
    public class SubscriptionPeriod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<DateTime> DeliveryDates { get; set; } = new List<DateTime>();

        // Relacionamento com OfertaProduto
        public List<ProductOffer> ProductOffers { get; set; } = new List<ProductOffer>();
    }
}
