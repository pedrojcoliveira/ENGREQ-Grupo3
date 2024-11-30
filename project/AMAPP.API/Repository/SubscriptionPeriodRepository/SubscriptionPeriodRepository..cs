using AMAPP.API.DTOs.Subscription;
using AMAPP.API.Models;
using System.Threading.Tasks;
using AMAPP.API.Data;

namespace AMAPP.API.Repository.SubscriptionPeriodRepository
{
    public class SubscriptionPeriodRepository : RepositoryBase<SubscriptionPeriod>, ISubscriptionPeriodRepository
    {
        public SubscriptionPeriodRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}