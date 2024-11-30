using System;
using System.Collections.Generic;

namespace AMAPP.API.DTOs.SubscriptionPeriod
{
    public class SubscriptionPeriodDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DateTime> DeliveryDates { get; set; } = new();
        public List<int> ProductOfferIds { get; set; } = new();
    }
}