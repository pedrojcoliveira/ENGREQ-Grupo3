using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.DTOs.SelectedProductOffer;

public class CreateSelectedProductOfferDto
{
        [Required] 
        public DateTime DeliveryDate { get; set; } = new();
        [Required]
        public int ProductOfferId { get; set; }
        [Required]
        public int SubscriptionId { get; set; }
        [Required]
        public int Quantity { get; set; }
}