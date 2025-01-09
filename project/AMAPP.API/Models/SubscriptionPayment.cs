using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AMAPP.API.Constants;

namespace AMAPP.API.Models
{
    public class SubscriptionPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public int SelectedProductOfferId { get; set; }
        public SelectedProductOffer SelectedProductOffer { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
