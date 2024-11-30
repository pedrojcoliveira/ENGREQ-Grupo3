using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.DTOs.Subscription
{
    public class CreateSubscriptionDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public SubscriptionDuration Duration { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public List<DateTime> DeliveryDates { get; set; }
        [Required]
        public ulong ProducerId { get; set; }
    }
}