using AMAPP.API.Models;
using AMAPP.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace AMAPP.API.Repository.SelectedProductOfferRepository;

public class SelectedProductOfferRepository : RepositoryBase<SelectedProductOffer>, ISelectedProductOfferRepository
{ 
    public SelectedProductOfferRepository(ApplicationDbContext context) : base(context)
    {
    }
    
        public new async Task<IEnumerable<SelectedProductOffer>> GetAllAsync()
        {
            return await _context.Set<SelectedProductOffer>()
                .Include(spo => spo.SubscriptionPayments)
                .ToListAsync();
        }
}