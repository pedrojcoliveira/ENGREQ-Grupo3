using static AMAPP.API.Constants;

namespace AMAPP.API.Models
{
    public class ProductOfferPaymentMode
    {
        public int ProductOfferId { get; set; }
        public ProductOffer ProductOffer { get; set; }

        public PaymentMode PaymentMode { get; set; } // Using enum
    }
}
