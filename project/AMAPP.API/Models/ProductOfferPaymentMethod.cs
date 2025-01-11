using static AMAPP.API.Constants;

namespace AMAPP.API.Models
{
    public class ProductOfferPaymentMethod
    {
        public int ProductOfferId { get; set; }
        public ProductOffer ProductOffer { get; set; }

        public PaymentMethod PaymentMethod { get; set; } // Using enum
    }
}
