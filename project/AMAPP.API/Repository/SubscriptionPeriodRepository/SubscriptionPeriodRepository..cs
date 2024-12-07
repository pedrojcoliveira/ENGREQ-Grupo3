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
        public new async Task<IEnumerable<SubscriptionPeriod>> GetAllAsync()
        {
            return await _context.SubscriptionPeriods
                .Include(sp => sp.DeliveryDates) 
                .ToListAsync();
        }
        
        public new async Task<SubscriptionPeriod?> GetByIdAsync(int id)
        {
            return await _context.SubscriptionPeriods
                .Include(sp => sp.DeliveryDates) 
                .FirstOrDefaultAsync(sp => sp.Id == id);
        }
        
    }
}