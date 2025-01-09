using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.Models
{
    public class SelectedDeliveryDate
    {
        public int DeliveryDateId { get; set; }
        public DeliveryDate DeliveryDate { get; set; }

        public int ProductOfferId { get; set; }
        public ProductOffer ProductOffer { get; set; }
    }
}
