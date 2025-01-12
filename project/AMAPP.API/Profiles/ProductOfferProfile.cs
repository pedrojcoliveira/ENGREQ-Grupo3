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

            CreateMap<ProductOffer, ProductOfferDto>()
                .ForMember(dest => dest.SelectedDeliveryDates, opt => opt.MapFrom(src => src.SelectedDeliveryDates.Select(sd => sd.DeliveryDateId).ToList())) // If you need to handle them separately
                .ForMember(dest => dest.ProductOfferPaymentMethodIds, opt => opt.MapFrom(src => src.ProductOfferPaymentMethods.Select(sd => sd.PaymentMethod).ToList()))// If you need to handle them separately
                .ForMember(dest => dest.ProductOfferPaymentModeIds, opt => opt.MapFrom(src => src.ProductOfferPaymentModes.Select(sd => sd.PaymentMode).ToList())); // If you need to handle them separately


            CreateMap<ProductOffer, ProductOfferResultDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.SubscriptionPeriodName, opt => opt.MapFrom(src => src.SubscriptionPeriod.Name))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.SelectedDeliveryDates, opt => opt.MapFrom(src => src.SelectedDeliveryDates.Select(sdd => sdd.DeliveryDate.Date).ToList()));
            

            CreateMap<CreateProductOfferDto, ProductOffer>()
                .ForMember(dest => dest.SelectedDeliveryDates, opt => opt.Ignore()) // If you need to handle them separately
                .ForMember(dest => dest.ProductOfferPaymentMethods, opt => opt.Ignore()) // If you need to handle them separately
                .ForMember(dest => dest.ProductOfferPaymentModes, opt => opt.Ignore()); // If you need to handle them separately

            CreateMap<ProductOffer, CreateProductOfferDto>();
            CreateMap<ProductOffer, ProductOfferDetailsDto>()
                ;

        }
    }
}

