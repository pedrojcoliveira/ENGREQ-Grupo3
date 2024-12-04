namespace AMAPP.API.Models;

public class DeliveryDateBase
{ 
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int SubscriptionPeriodId { get; set; }
        
}