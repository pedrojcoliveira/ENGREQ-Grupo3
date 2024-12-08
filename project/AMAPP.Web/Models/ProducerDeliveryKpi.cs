namespace AMAPP.Web.Models
{
    public class ProducerDeliveryKpi
    {
        public string ProducerName { get; set; }
        public string SubscriptionPeriodName { get; set; }
        public double DeliveryAverageValue { get; set; }
        public double PeriodTotalValue { get; set; }
    }
}
