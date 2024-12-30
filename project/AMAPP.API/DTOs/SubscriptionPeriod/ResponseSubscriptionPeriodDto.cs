using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.DTOs.SubscriptionPeriod
{
    public class ResponseSubscriptionPeriodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubscriptionDuration Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public List<DateTime> DeliveryDates { get; set; }
    }
}