using AutoMapper;
using AMAPP.API.Models;
using AMAPP.API.DTOs.ProductOffer;

namespace AMAPP.API.Profiles
{
    public class ProductOfferProfile : Profile
    {
        public ProductOfferProfile()
        {
            // Mapping from ProductOfferDto to ProductOffer
            CreateMap<ProductOfferDto, ProductOffer>()
                .ForMember(dest => dest.SelectedDeliveryDates, opt => opt.Ignore()) // If you need to handle them separately
                .ForMember(dest => dest.ProductOfferPaymentMethods, opt => opt.Ignore()) // If you need to handle them separately
                .ForMember(dest => dest.ProductOfferPaymentModes, opt => opt.Ignore()); // If you need to handle them separately

            CreateMap<ProductOffer, ProductOfferDto>();

            CreateMap<ProductOffer, ProductOfferResultDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.SubscriptionPeriodName, opt => opt.MapFrom(src => src.SubscriptionPeriod.Name));
            

            CreateMap<CreateProductOfferDto, ProductOffer>()
                .ForMember(dest => dest.SelectedDeliveryDates, opt => opt.Ignore()) // If you need to handle them separately
                .ForMember(dest => dest.ProductOfferPaymentMethods, opt => opt.Ignore()) // If you need to handle them separately
                .ForMember(dest => dest.ProductOfferPaymentModes, opt => opt.Ignore()); // If you need to handle them separately

            CreateMap<ProductOffer, CreateProductOfferDto>();

        }
    }
}

