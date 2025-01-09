using AMAPP.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAPP.API.Repository.ProductOfferRepository
{
    public interface IProductOfferRepository : IRepositoryBase<ProductOffer>
    {
        Task<List<ProductOffer>> GetByProducerIdAsync(int producerId);
        Task<List<ProductOffer>> GetBySubscriptionPeriodIdAsync(int subscriptionPeriodId);
        Task<List<ProductOffer>> GetAllProductOffersWithDetailsAsync();
        Task<List<ProductOffer>> GetProductOffersBySubscriptionPeriodId(int id);
    }
}


