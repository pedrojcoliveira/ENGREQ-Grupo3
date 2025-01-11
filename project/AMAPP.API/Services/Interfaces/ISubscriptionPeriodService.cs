using AMAPP.API.DTOs.DeliveryDate;
using AMAPP.API.DTOs.SubscriptionPeriod;


namespace AMAPP.API.Services.Interfaces
{
    public interface ISubscriptionPeriodService
    {
        Task<ResponseSubscriptionPeriodDto> AddSubscriptionPeriodAsync(CreateSubscriptionPeriodDto subscriptionPeriodDto);
        Task<List<ResponseSubscriptionPeriodDto>> GetAllSubscriptionPeriodsAsync();
        Task<ResponseSubscriptionPeriodDto> GetSubscriptionPeriodByIdAsync(int id);
        Task<ResponseSubscriptionPeriodDto> UpdateSubscriptionPeriodAsync(int id, SubscriptionPeriodDto subscriptionPeriodDto);
        Task<bool> DeleteSubscriptionPeriodAsync(int id);
        Task<List<DeliveryDateDto>> GetSubscriptionPeriodDatesById(int id);
    }
}