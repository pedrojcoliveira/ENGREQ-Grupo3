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

        public SubscriptionPeriodService(ISubscriptionPeriodRepository subscriptionPeriodRepository,
            IProductOfferRepository productOfferRepository,
            ISelectedProductOfferRepository selectedProductOfferRepository, IMapper mapper)
        {
            _subscriptionPeriodRepository = subscriptionPeriodRepository;
            _productOfferRepository = productOfferRepository;
            _selectedProductOfferRepository = selectedProductOfferRepository;
            _mapper = mapper;
        }

        public async Task<ResponseSubscriptionPeriodDto> AddSubscriptionPeriodAsync(
            CreateSubscriptionPeriodDto subscriptionPeriodDto)
        {
            /*
            var productOffers =
                await Task.WhenAll(
                    subscriptionPeriodDto.ProductOfferIds.Select(id => _productOfferRepository.GetByIdAsync(id)));
            if (productOffers.Any(po => po == null)) throw new Exception("One or more ProductOffer IDs are invalid.");

            var selectedProductOffers =
                await Task.WhenAll(subscriptionPeriodDto.SelectedProductOfferIds.Select(id =>
                    _selectedProductOfferRepository.GetByIdAsync(id)));
            if (selectedProductOffers.Any(spo => spo == null))
                throw new Exception("One or more SelectedProductOffer IDs are invalid.");*/

            var subscriptionPeriod =
                _mapper.Map<SubscriptionPeriod>(
                    subscriptionPeriodDto /*(subscriptionPeriodDto, productOffers, selectedProductOffers)*/);

            await _subscriptionPeriodRepository.AddAsync(subscriptionPeriod);
            return _mapper.Map<ResponseSubscriptionPeriodDto>(subscriptionPeriod);
        }

        public async Task<List<ResponseSubscriptionPeriodDto>> GetAllSubscriptionPeriodsAsync()
        {
            var subscriptionPeriods = await _subscriptionPeriodRepository.GetAllAsync();
            return _mapper.Map<List<ResponseSubscriptionPeriodDto>>(subscriptionPeriods);
        }

        public async Task<ResponseSubscriptionPeriodDto> GetSubscriptionPeriodByIdAsync(int id)
        {
            var subscriptionPeriod = await _subscriptionPeriodRepository.GetByIdAsync(id);
            if (subscriptionPeriod == null)
                return null;

            return _mapper.Map<ResponseSubscriptionPeriodDto>(subscriptionPeriod);
        }

        public async Task<ResponseSubscriptionPeriodDto> UpdateSubscriptionPeriodAsync(int id,
            SubscriptionPeriodDto subscriptionPeriodDto)
        {
            // Retrieve the existing SubscriptionPeriod by ID
            var subscriptionPeriod = await _subscriptionPeriodRepository.GetByIdAsync(id);
            if (subscriptionPeriod == null)
                return null;

            // Update the Name if provided
            if (!string.IsNullOrEmpty(subscriptionPeriodDto.Name))
                subscriptionPeriod.Name = subscriptionPeriodDto.Name;

            // Update StartDate if a valid, non-default date is provided
            if (subscriptionPeriodDto.StartDate != default && subscriptionPeriodDto.StartDate != DateTime.MinValue)
                subscriptionPeriod.StartDate = subscriptionPeriodDto.StartDate;

            // Update EndDate if a valid, non-default date is provided
            if (subscriptionPeriodDto.EndDate != default && subscriptionPeriodDto.EndDate != DateTime.MinValue)
                subscriptionPeriod.EndDate = subscriptionPeriodDto.EndDate;

            // Ensure EndDate is not earlier than StartDate
            if (subscriptionPeriod.StartDate > subscriptionPeriod.EndDate)
                throw new ArgumentException("EndDate cannot be earlier than StartDate.");

            // Map additional fields from DTO to the entity if necessary
            _mapper.Map(subscriptionPeriodDto, subscriptionPeriod);

            // Persist the updated entity to the repository
            await _subscriptionPeriodRepository.UpdateAsync(subscriptionPeriod);

            // Map the updated entity to the response DTO
            return _mapper.Map<ResponseSubscriptionPeriodDto>(subscriptionPeriod);
        }

        public async Task<bool> DeleteSubscriptionPeriodAsync(int id)
        {
            var subscriptionPeriod = await _subscriptionPeriodRepository.GetByIdAsync(id);
            if (subscriptionPeriod == null)
                return false;

            await _subscriptionPeriodRepository.RemoveAsync(subscriptionPeriod);
            return true;
        }
    }
}