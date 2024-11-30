using AMAPP.API.DTOs.Subscription;
using AMAPP.API.Models;
using System.Threading.Tasks;
using AMAPP.API.Data;

namespace AMAPP.API.Repository.SubscriptionRepository
{
    public class SubscriptionRepository : RepositoryBase<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}