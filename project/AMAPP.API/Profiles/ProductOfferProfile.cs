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


            CreateMap<ProductOffer, ProductOfferResultDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.SubscriptionPeriodName, opt => opt.MapFrom(src => src.PeriodSubscription.Name))
                .ForMember(dest => dest.SelectedDeliveryDates, opt => opt.MapFrom(src => src.SelectedDeliveryDates.Select(d => d.Date).ToList()));
        }
    }
}

