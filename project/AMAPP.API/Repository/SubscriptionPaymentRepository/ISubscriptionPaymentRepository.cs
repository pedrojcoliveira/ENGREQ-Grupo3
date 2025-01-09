using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Models;

namespace AMAPP.API.Repository.SubscriptionPaymentRepository
{
    public interface ISubscriptionPaymentRepository: IRepositoryBase<Payment>
    {

        Task<List<CoProducerDebts>> GetAllCoproducersDebts();

        Task<List<ProducerPendingPayments>> GetAllProducerPendingPayments();
    }
}
