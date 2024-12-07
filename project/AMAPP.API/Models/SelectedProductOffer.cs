using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.Models
{
    public class SelectedProductOffer
    {
        public int Id { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int ProductOfferId { get; set; }
        public ProductOffer ProductOffer { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public int Quantity { get; set; }

        // Pagamentos da subscrição
        public List<SubscriptionPayment> SubscriptionPayments { get; set; } = new();
        
        //novo com base na bd
        public int SubscriptionPeriodId { get; set; }

    }
}
