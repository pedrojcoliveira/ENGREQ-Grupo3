using AMAPP.API.Models;
using MediatR;

namespace AMAPP.API.Events
{
    public class SubscriptionPeriodCreatedEvent : INotification
    {
        public SubscriptionPeriod NewlyCreatedSubscriptionPeriod { get; set; }
    }
}