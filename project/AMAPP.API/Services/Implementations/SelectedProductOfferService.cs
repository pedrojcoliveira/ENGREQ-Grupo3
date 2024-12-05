using AMAPP.API.DTOs.SelectedProductOffer;
using AMAPP.API.Models;
using AMAPP.API.Repository.SelectedProductOfferRepository;
using AMAPP.API.Services.Interfaces;
using AutoMapper;

namespace AMAPP.API.Services.Implementations;

public class SelectedProductOfferService : ISelectedProductOfferService
{
    private readonly ISelectedProductOfferRepository selectedProductOfferRepository;
    private readonly IMapper mapper;

    public SelectedProductOfferService(ISelectedProductOfferRepository selectedProductOfferRepository, IMapper mapper)
    {
        this.selectedProductOfferRepository = selectedProductOfferRepository;
        this.mapper = mapper;
    }

    public async Task<ResponseSelectedProductOfferDto> AddSelectedProductOfferAsync(CreateSelectedProductOfferDto createSelectedProductOfferDto)
    {
        var selectedProductOffer = mapper.Map<SelectedProductOffer>(createSelectedProductOfferDto);
    
        await selectedProductOfferRepository.AddAsync(selectedProductOffer);
    
        return mapper.Map<ResponseSelectedProductOfferDto>(selectedProductOffer);
    
    }

    public async Task<List<ResponseSelectedProductOfferDto>> GetAllSelectedProductOffersAsync()
    {
        var selectedProductOffers = await selectedProductOfferRepository.GetAllAsync();
        return mapper.Map<List<ResponseSelectedProductOfferDto>>(selectedProductOffers);
    }

    public async Task<ResponseSelectedProductOfferDto> GetSelectedProductOfferByIdAsync(int id)
    {
        var selectedProductOffer = await selectedProductOfferRepository.GetByIdAsync(id);
        if (selectedProductOffer == null)
        {
            return null;
        }
        return mapper.Map<ResponseSelectedProductOfferDto>(selectedProductOffer);
    }

public async Task<ResponseSelectedProductOfferDto> UpdateSelectedProductOfferAsync(int id, SelectedProductOfferDto updateSelectedProductOfferDto)
{
    // Retrieve the existing SelectedProductOffer by ID
    var selectedProductOffer = await selectedProductOfferRepository.GetByIdAsync(id);
    if (selectedProductOffer == null)
    {
        return null;
    }

    // Update DeliveryDate if a valid, non-default date is provided
    if (updateSelectedProductOfferDto.DeliveryDate != default && updateSelectedProductOfferDto.DeliveryDate != DateTime.MinValue)
        selectedProductOffer.DeliveryDate = updateSelectedProductOfferDto.DeliveryDate;

    // Update ProductOfferId if provided and greater than 0
    if (updateSelectedProductOfferDto.ProductOfferId > 0)
        selectedProductOffer.ProductOfferId = updateSelectedProductOfferDto.ProductOfferId;

    // Update SubscriptionId if provided and greater than 0
    if (updateSelectedProductOfferDto.SubscriptionId > 0)
        selectedProductOffer.SubscriptionId = updateSelectedProductOfferDto.SubscriptionId;

    // Update Quantity if provided and greater than 0
    if (updateSelectedProductOfferDto.Quantity >= 0)
        selectedProductOffer.Quantity = updateSelectedProductOfferDto.Quantity;

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
            return false;
        }

        await selectedProductOfferRepository.RemoveAsync(selectedProductOffer);
        return true;
    }
}