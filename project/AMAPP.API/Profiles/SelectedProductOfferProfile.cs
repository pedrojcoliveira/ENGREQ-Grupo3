using AutoMapper;
using AMAPP.API.DTOs.SelectedProductOffer;
using AMAPP.API.Models;

namespace AMAPP.API.Profiles
{
    public class SelectedProductOfferProfile : Profile
    {
        public SelectedProductOfferProfile()
        {
            CreateMap<CreateSelectedProductOfferDto, SelectedProductOffer>();
            CreateMap<SelectedProductOffer, ResponseSelectedProductOfferDto>();
        }
        
    }
}