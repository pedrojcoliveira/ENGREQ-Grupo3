using AMAPP.API.DTOs.AccountBalance;
using AMAPP.API.Repository.AccountBalanceRepository;
using AMAPP.API.Repository.SelectedProductOfferRepository;
using AMAPP.API.Services.Interfaces;

namespace AMAPP.API.Services.Implementations
{
    public class AccountBalanceService : IAccountBalanceService
    {
        private readonly IAccountBalanceRepository _accountBalanceService;
        private readonly ISubscriptionPaymentService _subscriptionPaymentService;
        private readonly ISelectedProductOfferRepository _selectedProductOfferRepository;

        public AccountBalanceService(IAccountBalanceRepository accountBalanceService, ISubscriptionPaymentService subscriptionPaymentService, ISelectedProductOfferRepository selectedProductOfferRepository)
        {
            _accountBalanceService = accountBalanceService;
            _subscriptionPaymentService = subscriptionPaymentService;
            _selectedProductOfferRepository = selectedProductOfferRepository;
        }

        public async Task<List<CoproducerAccountBalanceDTO>> SetAccountBalance()
        {
            var coproducerbalance = await _selectedProductOfferRepository.TotalCoproducersProductValues();

            return coproducerbalance;
        }
    }
}
