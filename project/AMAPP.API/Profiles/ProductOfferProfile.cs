using AutoMapper;
using AMAPP.API.Models;
using AMAPP.API.DTOs.ProductOffer;

namespace AMAPP.API.Profiles
{
    public class ProductOfferProfile : Profile
    {
        public ProductOfferProfile()
        {
            CreateMap<ProductOfferDto, ProductOffer>()
                .ForMember(dest => dest.SelectedDeliveryDates, opt => opt.MapFrom(src => src.SelectedDeliveryDates.Select(date => new SelectedDeliveryDate { Date = date }).ToList()));

            CreateMap<ProductOffer, ProductOfferDto>()
                .ForMember(dest => dest.SelectedDeliveryDates, opt => opt.MapFrom(src => src.SelectedDeliveryDates.Select(date => date.Date).ToList()));
        }
    }
}

