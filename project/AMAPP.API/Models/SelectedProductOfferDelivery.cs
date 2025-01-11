using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static AMAPP.API.Constants;

namespace AMAPP.API.Models
{
    public class SelectedProductOfferDelivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SelectedProductOfferId { get; set; }
        public SelectedProductOffer SelectedProductOffer { get; set; }
        public int DeliveryDateId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public double DeliveredAmount { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}
