using AMAPP.API.Models;
using System.Threading.Tasks;
using AMAPP.API.Data;
namespace AMAPP.API.Repository.ProductOfferRepository;

public class ProductOfferRepository : RepositoryBase<ProductOffer>, IProductOfferRepository
{ 
    public ProductOfferRepository(ApplicationDbContext context) : base(context)
    {
    }
}