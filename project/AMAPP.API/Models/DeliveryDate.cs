using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.Models
{
    public class DeliveryDate
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int SubscriptionPeriodId { get; set; }
        
    }
}
