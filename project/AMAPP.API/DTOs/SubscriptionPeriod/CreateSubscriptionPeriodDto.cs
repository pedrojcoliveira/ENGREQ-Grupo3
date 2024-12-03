using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.DTOs.SubscriptionPeriod
{
    public class CreateSubscriptionPeriodDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public List<DateTime> Dates { get; set; }
    }
}