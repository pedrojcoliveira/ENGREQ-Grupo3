using AMAPP.API.Models;
using AMAPP.API.Data;
namespace AMAPP.API.Repository.SelectedProductOfferRepository;

public class SelectedProductOfferRepository : RepositoryBase<SelectedProductOffer>, ISelectedProductOfferRepository
{ 
    public SelectedProductOfferRepository(ApplicationDbContext context) : base(context)
    {
    }
    /*public new async Task<IEnumerable<SelectedProductOffer>> GetAllAsync()
        {
            return await _context.SubscriptionPeriods
                .Include(sp => sp.DeliveryDatesList) 
                .ToListAsync();
        }
    */
}