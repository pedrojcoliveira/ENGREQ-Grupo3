using AMAPP.API.DTOs.Product;
using AMAPP.API.Services.Interfaces;
using AMAPP.API.DTOs.SubscriptionPeriod;
using AMAPP.API.Events;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProductOfferRepository;
using AMAPP.API.Repository.SelectedProductOfferRepository;
using AMAPP.API.Repository.SubscriptionPeriodRepository;
using AutoMapper;
using MediatR;

namespace AMAPP.API.Services
{
    public class SubscriptionPeriodService : ISubscriptionPeriodService
    {
        private readonly ISubscriptionPeriodRepository _subscriptionPeriodRepository;
        private readonly IProductOfferRepository _productOfferRepository;
        private readonly ISelectedProductOfferRepository _selectedProductOfferRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SubscriptionPeriodService(ISubscriptionPeriodRepository subscriptionPeriodRepository,
            IProductOfferRepository productOfferRepository,
            ISelectedProductOfferRepository selectedProductOfferRepository, IMapper mapper, IMediator mediator)
        {
            _subscriptionPeriodRepository = subscriptionPeriodRepository;
            _productOfferRepository = productOfferRepository;
            _selectedProductOfferRepository = selectedProductOfferRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseSubscriptionPeriodDto> AddSubscriptionPeriodAsync(
            CreateSubscriptionPeriodDto subscriptionPeriodDto)
        {
            var subscriptionPeriod =
                _mapper.Map<SubscriptionPeriod>(
                    subscriptionPeriodDto);

            await _subscriptionPeriodRepository.AddAsync(subscriptionPeriod);
            await _mediator.Publish(new SubscriptionPeriodCreatedEvent
            {
                NewlyCreatedSubscriptionPeriod = subscriptionPeriod
            });
            
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
        
        public async Task<ResponseSubscriptionPeriodPlanDto> AddSubscriptionPeriodPlanAsync(CreateSubscriptionPeriodPlanDto subscriptionPeriodPlanDto)
{
    /*
     *logic to be implemented here
     * 
     */

    //validate if they exist by id
    var selectedProductOfferIds = subscriptionPeriodPlanDto.SelectedProductOfferIds;
    var productOfferIds = subscriptionPeriodPlanDto.ProductOfferIds;
    //if they exist generate
    var selectedProductOfferList = new List<SelectedProductOffer>();
    var productOfferList = new List<ProductOffer>();
    // create the SubscriptionPeriod model -> call repository like in AddSubscriptionPeriodAsync and get the id
    //update each SelectedProductOffer and ProductOffer with the SubscriptionPeriodId and call the respective repository update method
    //return all the data from the models and build the composite ResponseSubscriptionPeriodPlanDto
    
    /*
    // Validate the subscription period
    var subscriptionPeriod = _mapper.Map<SubscriptionPeriod>(subscriptionPeriodPlanDto.SubscriptionPeriod);
    await _subscriptionPeriodRepository.AddAsync(subscriptionPeriod);

    // Validate and map the selected product offers
    var selectedProductOffers = await Task.WhenAll(subscriptionPeriodPlanDto.SelectedProductOfferIds.Select(id => _selectedProductOfferRepository.GetByIdAsync(id)));
    if (selectedProductOffers.Any(spo => spo == null))
        throw new Exception("One or more SelectedProductOffer IDs are invalid.");

    // Validate and map the product offers
    var productOffers = await Task.WhenAll(subscriptionPeriodPlanDto.ProductOfferIds.Select(id => _productOfferRepository.GetByIdAsync(id)));
    if (productOffers.Any(po => po == null))
        throw new Exception("One or more ProductOffer IDs are invalid.");

    // Create the response DTO
    var response = new ResponseSubscriptionPeriodPlanDto
    {
        SubscriptionPeriod = _mapper.Map<ResponseSubscriptionPeriodDto>(subscriptionPeriod),
        SelectedProductOffers = _mapper.Map<List<ResponseSelectedProductOfferDto>>(selectedProductOffers),
        ProductOffers = _mapper.Map<List<ResponseProductOfferDto>>(productOffers)
    };

    return response;
    */
    throw new NotImplementedException();
}
    }
}