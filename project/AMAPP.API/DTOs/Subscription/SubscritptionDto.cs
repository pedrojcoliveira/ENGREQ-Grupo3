    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace AMAPP.API.DTOs.Subscription; 

    public class SubscriptionDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public List<DateTime> DeliveryDates { get; set; }
    }
