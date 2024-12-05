using AMAPP.API.DTOs.SelectedProductOffer;

namespace AMAPP.API.Services.Interfaces;

public interface ISelectedProductOfferService
{
        Task<ResponseSelectedProductOfferDto> AddSelectedProductOfferAsync(CreateSelectedProductOfferDto createSelectedProductOfferDto);
        Task<List<ResponseSelectedProductOfferDto>> GetAllSelectedProductOffersAsync();
        Task<ResponseSelectedProductOfferDto> GetSelectedProductOfferByIdAsync(int id);
        Task<ResponseSelectedProductOfferDto> UpdateSelectedProductOfferAsync(int id, SelectedProductOfferDto updateSelectedProductOfferDto);
        Task<bool> DeleteSelectedProductOfferAsync(int id);
}