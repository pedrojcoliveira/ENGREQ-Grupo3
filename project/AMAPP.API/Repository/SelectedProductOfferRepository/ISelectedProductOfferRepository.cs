using AMAPP.API.DTOs.AccountBalance;
using AMAPP.API.Models;

namespace AMAPP.API.Repository.SelectedProductOfferRepository;

public interface ISelectedProductOfferRepository: IRepositoryBase<SelectedProductOffer>
{
    Task<bool> UpdateQuantityAsync(int id, int quantity);
    Task<List<CoproducerAccountBalanceDTO>> TotalCoproducersProductValues();
    //Task<List<SelectedProductOffer>> GetSelectedProductOffersBySubscriptionPeriodId(int id);
}
