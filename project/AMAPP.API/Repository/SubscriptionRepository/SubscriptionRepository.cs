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
        
        public new async Task<Subscription?> GetByIdAsync(int id)
        {
            return await _context.Subscriptions
                .FirstOrDefaultAsync(sp => sp.Id == id);
        }
        
        // Get subscriptions by subscription period id
        // Use case: check if subscription period can be deleted
        public async Task<List<Subscription>> GetSubscriptionsBySubscriptionPeriodId(int id)
        {
            return await _context.Subscriptions
                .Where(sp => sp.SubscriptionPeriod.Id == id)
                .ToListAsync();
        }
        
    }
}