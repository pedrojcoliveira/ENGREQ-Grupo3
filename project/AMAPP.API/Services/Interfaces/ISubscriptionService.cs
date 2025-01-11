using AMAPP.API.DTOs.Subscription;

namespace AMAPP.API.Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<SubscriptionDto> AddSubscriptionAsync(CreateSubscriptionDto subscriptionDto);
    }
}
