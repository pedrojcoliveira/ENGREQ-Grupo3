using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveredAmount { get; set; }
        public string Status { get; set; }
    }
}
