using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AMAPP.API.Constants;

namespace AMAPP.API.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SelectedProductOfferId { get; set; }
        public SelectedProductOffer SelectedProductOffer { get; set; }

        public int? SelectedProductOfferDeliveryId { get; set; }
        public SelectedProductOfferDelivery SelectedProductOfferDelivery { get; set; }

        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; } // Enum
        public PaymentMode PaymentMode { get; set; } // Enum
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
