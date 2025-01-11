using AMAPP.API.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMAPP.API.Models
{
    public class SelectedProductOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public int ProductOfferId { get; set; }
        public ProductOffer ProductOffer { get; set; }

        public ICollection<SelectedProductOfferDelivery> SelectedProductOfferDeliveries { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
