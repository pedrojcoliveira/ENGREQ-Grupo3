using AMAPP.API.Models;
using System.Threading.Tasks;
using AMAPP.API.Data;
using Microsoft.EntityFrameworkCore;

namespace AMAPP.API.Repository.SubscriptionPeriodRepository
{
    public class SubscriptionPeriodRepository : RepositoryBase<SubscriptionPeriod>, ISubscriptionPeriodRepository
    {
        public SubscriptionPeriodRepository(ApplicationDbContext context) : base(context)
        {
        }
        
    }
}