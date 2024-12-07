using AMAPP.API.Data;
using AMAPP.API.Models;

namespace AMAPP.API.Repository.SubscriptionPaymentRepository
{
    public class SubscriptionPaymentRepository : RepositoryBase<SubscriptionPayment>, ISubscriptionPaymentRepository
    {
        public SubscriptionPaymentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
