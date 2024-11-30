using AMAPP.API.Models;
using AMAPP.API.Data;
namespace AMAPP.API.Repository.SelectedProductOfferRepository;

public class SelectedProductOfferRepository : RepositoryBase<SelectedProductOffer>, ISelectedProductOfferRepository
{ 
    public SelectedProductOfferRepository(ApplicationDbContext context) : base(context)
    {
    }
}