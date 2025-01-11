using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AMAPP.API.Constants;


namespace AMAPP.API.Models
{
    public class ProductOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SubscriptionPeriodId { get; set; }
        public SubscriptionPeriod SubscriptionPeriod { get; set; }
        public List<SelectedDeliveryDate> SelectedDeliveryDates { get; set; } = new List<SelectedDeliveryDate>();
        public List<ProductOfferPaymentMethod> ProductOfferPaymentMethods { get; set; } = new List<ProductOfferPaymentMethod>();
        public List<ProductOfferPaymentMode> ProductOfferPaymentModes { get; set; } = new List<ProductOfferPaymentMode>();
        public ICollection<SelectedProductOffer> SelectedProductOffers { get; set; }

    }

}
