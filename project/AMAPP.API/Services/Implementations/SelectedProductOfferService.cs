using AMAPP.API.DTOs.SelectedProductOffer;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProductOfferRepository;
using AMAPP.API.Repository.SelectedProductOfferRepository;
using AMAPP.API.Repository.SubscriptionRepository;
using AMAPP.API.Services.Interfaces;
using AMAPP.API.Utils;
using AutoMapper;

namespace AMAPP.API.Services.Implementations;

public class SelectedProductOfferService : ISelectedProductOfferService
{
    private readonly ISelectedProductOfferRepository selectedProductOfferRepository;
    private readonly IProductOfferRepository productOfferRepository;
    private readonly ISubscriptionRepository subscriptionRepository;
    private readonly IMapper mapper;

    public SelectedProductOfferService(ISelectedProductOfferRepository selectedProductOfferRepository, IProductOfferRepository productOfferRepository, ISubscriptionRepository subscriptionRepository, IMapper mapper)
    {
        this.selectedProductOfferRepository = selectedProductOfferRepository;
        this.productOfferRepository = productOfferRepository;
        this.subscriptionRepository = subscriptionRepository;
        this.mapper = mapper;
    }

    public async Task<ResponseSelectedProductOfferDto> AddSelectedProductOfferAsync(CreateSelectedProductOfferDto createSelectedProductOfferDto)
    {
        
        // Validate if ProductOfferId exists
        var productOffer = await productOfferRepository.GetByIdAsync(createSelectedProductOfferDto.ProductOfferId);
        if (productOffer is null)
        {
            throw new NotFoundException("A Oferta de Produto não existe");
        }

        // Validate if SubscriptionId exists
        var subscription = await subscriptionRepository.GetByIdAsync(createSelectedProductOfferDto.SubscriptionId);
        if (subscription is null)
        {
            throw new Exception("A Subscrição não existe");
        }
        
        var selectedProductOffer = mapper.Map<SelectedProductOffer>(createSelectedProductOfferDto);
        //add subscription period id from the subscription
        selectedProductOffer.SubscriptionPeriodId = subscription.SubscriptionPeriodId;
    
        await selectedProductOfferRepository.AddAsync(selectedProductOffer);
    
        return mapper.Map<ResponseSelectedProductOfferDto>(selectedProductOffer);
    
    }

public async Task<List<ResponseSelectedProductOfferDto>> GetAllSelectedProductOffersAsync()
{
    var selectedProductOffers = (await selectedProductOfferRepository.GetAllAsync()).ToList();
    
    return mapper.Map<List<ResponseSelectedProductOfferDto>>(selectedProductOffers);
}

    public async Task<ResponseSelectedProductOfferDto> GetSelectedProductOfferByIdAsync(int id)
    {
        var selectedProductOffer = await selectedProductOfferRepository.GetByIdAsync(id);
        if (selectedProductOffer == null)
        {
            throw new NotFoundException("A Oferta de Produto Subscripta não existe");
        }
        return mapper.Map<ResponseSelectedProductOfferDto>(selectedProductOffer);
    }

    public async Task<ResponseSelectedProductOfferDto> UpdateSelectedProductOfferAsync(int id, SelectedProductOfferDto updateSelectedProductOfferDto)
    {
        // Retrieve the existing SelectedProductOffer by ID
        var selectedProductOffer = await selectedProductOfferRepository.GetByIdAsync(id);
        if (selectedProductOffer == null)
        {
            throw new NotFoundException("A Oferta de Produto Subscrita não existe");
        }

        // Update DeliveryDate if a valid, non-default date is provided
        if (updateSelectedProductOfferDto.DeliveryDate != default && updateSelectedProductOfferDto.DeliveryDate != DateTime.MinValue)
            selectedProductOffer.DeliveryDate = updateSelectedProductOfferDto.DeliveryDate;
        
        // Update ProductOfferId if provided and greater than 0
        if (updateSelectedProductOfferDto.ProductOfferId > 0)
        {
            var productOfferExists = await productOfferRepository.GetByIdAsync(updateSelectedProductOfferDto.ProductOfferId);
            if (productOfferExists == null)
            {
                throw new NotFoundException("A Oferta de Produto selecionada não existe");
            }
            selectedProductOffer.ProductOfferId = updateSelectedProductOfferDto.ProductOfferId;
        }

        // Update SubscriptionId if provided and greater than 0
        if (updateSelectedProductOfferDto.SubscriptionId > 0)
        {
            var subscriptionExists = await subscriptionRepository.GetByIdAsync(updateSelectedProductOfferDto.SubscriptionId);
            if (subscriptionExists == null)
            {
                throw new NotFoundException("A Subscrição selecionada não existe");
            }
            selectedProductOffer.SubscriptionId = updateSelectedProductOfferDto.SubscriptionId; 
            //add subscription period id from the updated subscription
            selectedProductOffer.SubscriptionPeriodId = subscriptionExists.SubscriptionPeriodId;
        }

        // Update Quantity if provided and greater than 0
        if (updateSelectedProductOfferDto.Quantity >= 0)
            selectedProductOffer.Quantity = updateSelectedProductOfferDto.Quantity.Value;
    

        // Persist the updated entity to the repository
        await selectedProductOfferRepository.UpdateAsync(selectedProductOffer);

        // Map the updated entity to the response DTO
        return mapper.Map<ResponseSelectedProductOfferDto>(selectedProductOffer);
    }

    public async Task<bool> DeleteSelectedProductOfferAsync(int id)
    {
        var selectedProductOffer = await selectedProductOfferRepository.GetByIdAsync(id);
        if (selectedProductOffer == null)
        {
            throw new NotFoundException("A Oferta de Produto Subscrita não existe");
        }

        await selectedProductOfferRepository.RemoveAsync(selectedProductOffer);
        return true;
    }
}