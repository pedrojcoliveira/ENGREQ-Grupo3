using AMAPP.API.DTOs.AccountBalance;

namespace AMAPP.API.Services.Interfaces
{
    public interface IAccountBalanceService
    {
        Task<List<CoproducerAccountBalanceDTO>> SetAccountBalance();
    }
}
