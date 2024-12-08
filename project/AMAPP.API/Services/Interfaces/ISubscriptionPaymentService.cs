using AMAPP.API.DTOs.SubscriptionPayment;

namespace AMAPP.API.Services.Interfaces
{
    public interface ISubscriptionPaymentService
    {
        Task<List<CoProducerDebts>> GetAllCoproducersDepts();
        Task<List<ProducerPendingPayments>> GetAllProducerPendingPayments();
    }
}
