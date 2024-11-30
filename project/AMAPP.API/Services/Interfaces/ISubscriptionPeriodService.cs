using AMAPP.API.DTOs.SubscriptionPeriod;


namespace AMAPP.API.Services.Interfaces
{
    public interface ISubscriptionPeriodService
    {
        Task<SubscriptionPeriodDto> AddSubscriptionPeriodAsync(CreateSubscriptionPeriodDto subscriptionPeriodDto);

    }
}