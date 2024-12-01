using AMAPP.API.DTOs.Subscription;
using AMAPP.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAPP.API.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        // Other methods...

        /*public async Task<bool> SoftDeleteSubscriptionAsync(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
                return false;

            subscription.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }*/
    }
}