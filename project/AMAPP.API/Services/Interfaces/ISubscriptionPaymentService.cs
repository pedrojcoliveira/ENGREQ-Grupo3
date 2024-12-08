using AMAPP.API.DTOs.SubscriptionPayment;

namespace AMAPP.API.Services.Interfaces
{
    public interface ISubscriptionPaymentService
    {
        Task<List<CoProducerDebts>> GetAllCoproducersDepts();
        Task<List<ProducerPendingPayments>> GetAllProducerPendingPayments();
        
        Task<ResponseSubscriptionPaymentDto> AddSubscriptionPaymentAsync(CreateSubscriptionPaymentDto createSubscriptionPaymentDto);
        Task<List<ResponseSubscriptionPaymentDto>> GetAllSubscriptionPaymentsAsync();
        Task<ResponseSubscriptionPaymentDto> GetSubscriptionPaymentByIdAsync(int id);
        Task<ResponseSubscriptionPaymentDto> UpdateSubscriptionPaymentAsync(int id, UpdateSubscriptionPaymentDto updateSubscriptionPaymentDto);
        Task<bool> DeleteSubscriptionPaymentAsync(int id);
    }
}
