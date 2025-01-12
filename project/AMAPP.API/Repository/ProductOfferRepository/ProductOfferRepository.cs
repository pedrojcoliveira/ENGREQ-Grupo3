using AMAPP.API.Data;
using AMAPP.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMAPP.API.Repository.ProductOfferRepository
{
    public class ProductOfferRepository : RepositoryBase<ProductOffer>, IProductOfferRepository
    {
        public ProductOfferRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<ProductOffer>> GetByProducerIdAsync(int producerId)
        {
            return await _context.ProductOffers
                .Include(po => po.Product)
                .Where(po => po.Product.ProducerInfoId == producerId)
                .ToListAsync();
        }

        public async Task<List<ProductOffer>> GetBySubscriptionPeriodIdAsync(int subscriptionPeriodId)
        {
            return await _context.ProductOffers
                .Where(po => po.SubscriptionPeriodId == subscriptionPeriodId)
                .ToListAsync();
        }

        public async Task<List<ProductOffer>> GetAllProductOffersWithDetailsAsync()
        {
            return await _context.ProductOffers
                .Include(po => po.Product)
                .Include(po => po.SelectedDeliveryDates).ThenInclude(x => x.DeliveryDate)
                .Include(po => po.SubscriptionPeriod)
                .ToListAsync();
        }
        
        // Get product offers by subscription period id
        // Use case: check if subscription period can be deleted
        public async Task<List<ProductOffer>> GetProductOffersBySubscriptionPeriodId(int id)
        {
            return await _context.ProductOffers
                .Where(po => po.SubscriptionPeriodId == id)
                .ToListAsync();
        }

        public Task<List<ProductOffer>> GetProductOffersByIds(IEnumerable<int> enumerable)
        {
            return _context.ProductOffers
                .Include(po => po.Product)
                .Where(po => enumerable.Contains(po.Id))
                .ToListAsync();
        }
        public new async Task<ProductOffer?> GetByIdAsync(int id)
        {
            return await _context.ProductOffers
                .Include(sp => sp.ProductOfferPaymentMethods)
                .Include(sp => sp.ProductOfferPaymentModes)
                .Include(sp => sp.SelectedDeliveryDates).ThenInclude(x => x.DeliveryDate)
                .FirstOrDefaultAsync(sp => sp.Id == id);
        }

    }
}

