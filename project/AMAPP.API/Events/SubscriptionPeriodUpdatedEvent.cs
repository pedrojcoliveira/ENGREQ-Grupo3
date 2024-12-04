using AMAPP.API.Models;
using MediatR;

namespace AMAPP.API.Events
{
    public class SubscriptionPeriodUpdatedEvent : INotification
    {
        public SubscriptionPeriod NewlyUpdatedSubscriptionPeriod { get; set; }
    }
}