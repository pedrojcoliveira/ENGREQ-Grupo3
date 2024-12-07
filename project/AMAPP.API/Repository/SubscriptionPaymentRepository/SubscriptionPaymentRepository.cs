using AMAPP.API.Data;
using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Models;

namespace AMAPP.API.Repository.SubscriptionPaymentRepository
{
    public class SubscriptionPaymentRepository : RepositoryBase<SubscriptionPayment>, ISubscriptionPaymentRepository
    {
        public SubscriptionPaymentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<CoProducerDebts>> GetAllCoproducersDebts()
        {
            List<CoProducerDebts> coproducersDebts = new();

            return coproducersDebts;
        }

        public async Task<List<ProducerPendingPayments>> GetAllProducerPendingPayments()
        {
            List<ProducerPendingPayments> producerPendingPayments = new();

            return producerPendingPayments;
        }
    }
}
