namespace AMAPP.Web.Models
{
    public class CreateSubscription
    {
        public int SubscriptionPeriodId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public int ProductOffer { get; set; }
        //public SubscriptionProductOfferDates SubscriptionProductOfferDates { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public PaymentMode PaymentMode { get; set; }
    }

    //public class SubscriptionProductOfferDates
    //{
    //    public DateTime DeliveryDate { get; set; }
    //    public double Amount { get; set; }
    //}
}
