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
                .Where(po => po.PeriodSubscriptionId == subscriptionPeriodId)
                .ToListAsync();
        }

        public async Task<List<ProductOffer>> GetAllProductOffersWithDetailsAsync()
        {
            return await _context.ProductOffers
                .Include(po => po.Product)
                .Include(po => po.SelectedDeliveryDates)
                .Include(po => po.PeriodSubscription)
                .ToListAsync();
        }
    }
}

