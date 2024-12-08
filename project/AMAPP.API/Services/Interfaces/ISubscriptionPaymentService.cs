using AMAPP.API.DTOs.SubscriptionPayment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAPP.API.Services.Interfaces
{
    public interface ISubscriptionPaymentService
    {
        Task<ResponseSubscriptionPaymentDto> AddSubscriptionPaymentAsync(CreateSubscriptionPaymentDto createSubscriptionPaymentDto);
        Task<List<ResponseSubscriptionPaymentDto>> GetAllSubscriptionPaymentsAsync();
        Task<ResponseSubscriptionPaymentDto> GetSubscriptionPaymentByIdAsync(int id);
        Task<ResponseSubscriptionPaymentDto> UpdateSubscriptionPaymentAsync(int id, SubscriptionPaymentDto updateSubscriptionPaymentDto);
        Task<bool> DeleteSubscriptionPaymentAsync(int id);
    }
}