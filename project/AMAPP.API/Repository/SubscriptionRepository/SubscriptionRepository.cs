using AMAPP.API.Data;
using AMAPP.API.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AMAPP.API.Repository.SubscriptionRepository
{
    public class SubscriptionRepository : RepositoryBase<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext context) : base(context)
        {
        }
        
    }
}