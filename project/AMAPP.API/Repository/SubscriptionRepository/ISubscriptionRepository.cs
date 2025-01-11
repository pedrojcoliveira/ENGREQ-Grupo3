using AMAPP.API.Models;
using System.Threading.Tasks;

namespace AMAPP.API.Repository.SubscriptionRepository
{
    public interface ISubscriptionRepository : IRepositoryBase<Subscription>
    {
        Task<List<Subscription>> GetSubscriptionsBySubscriptionPeriodId(int id);
    }
}