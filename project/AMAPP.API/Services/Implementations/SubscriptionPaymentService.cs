using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Repository.SubscriptionPaymentRepository;
using AMAPP.API.Services.Interfaces;

namespace AMAPP.API.Services.Implementations
{
    public class SubscriptionPaymentService: ISubscriptionPaymentService
    {
        private readonly ISubscriptionPaymentRepository _subscriptionPaymentRepository;

        public SubscriptionPaymentService(ISubscriptionPaymentRepository subscriptionPaymentRepository)
        {
            _subscriptionPaymentRepository = subscriptionPaymentRepository;
        }

        public async Task<List<CoProducerDebts>> GetAllCoproducersDepts()
        {
            var coproducersDebts = await _subscriptionPaymentRepository.GetAllCoproducersDebts();

            return coproducersDebts;
        }

        public async Task<List<ProducerPendingPayments>> GetAllProducerPendingPayments()
        {
            var producerPendingPayments = await _subscriptionPaymentRepository.GetAllProducerPendingPayments();

            return producerPendingPayments;
        }
    }
}
