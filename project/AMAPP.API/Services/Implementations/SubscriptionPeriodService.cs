using AMAPP.API.DTOs.Product;
using AMAPP.API.Services.Interfaces;
using AMAPP.API.DTOs.SubscriptionPeriod;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProductOfferRepository;
using AMAPP.API.Repository.SelectedProductOfferRepository;
using AMAPP.API.Repository.SubscriptionPeriodRepository;
using AutoMapper;

namespace AMAPP.API.Services
{
    public class SubscriptionPeriodService : ISubscriptionPeriodService
    {
        private readonly ISubscriptionPeriodRepository _subscriptionPeriodRepository;
        private readonly IProductOfferRepository _productOfferRepository;
        private readonly ISelectedProductOfferRepository _selectedProductOfferRepository;
        private readonly IMapper _mapper;

        public SubscriptionPeriodService(ISubscriptionPeriodRepository subscriptionPeriodRepository, IProductOfferRepository productOfferRepository, ISelectedProductOfferRepository selectedProductOfferRepository, IMapper mapper)
        {
            _subscriptionPeriodRepository = subscriptionPeriodRepository;
            _productOfferRepository = productOfferRepository;
            _selectedProductOfferRepository = selectedProductOfferRepository;
            _mapper = mapper;
        }

        public async Task<SubscriptionPeriodDto> AddSubscriptionPeriodAsync(
            CreateSubscriptionPeriodDto subscriptionPeriodDto)
        {
            var productOffers =
                await Task.WhenAll(
                    subscriptionPeriodDto.ProductOfferIds.Select(id => _productOfferRepository.GetByIdAsync(id)));
            if (productOffers.Any(po => po == null)) throw new Exception("One or more ProductOffer IDs are invalid.");

            var selectedProductOffers =
                await Task.WhenAll(subscriptionPeriodDto.SelectedProductOfferIds.Select(id =>
                    _selectedProductOfferRepository.GetByIdAsync(id)));
            if (selectedProductOffers.Any(spo => spo == null))
                throw new Exception("One or more SelectedProductOffer IDs are invalid.");

            var subscriptionPeriod =
                _mapper.Map<SubscriptionPeriod>((subscriptionPeriodDto, productOffers, selectedProductOffers));

            await _subscriptionPeriodRepository.AddAsync(subscriptionPeriod);
            return _mapper.Map<SubscriptionPeriodDto>(subscriptionPeriod);
        }
    }
}