using System;
using System.Collections.Generic;

namespace AMAPP.API.DTOs.SubscriptionPeriod
{
    public class SubscriptionPeriodDto
    {
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}