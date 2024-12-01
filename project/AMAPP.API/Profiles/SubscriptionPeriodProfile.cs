using AMAPP.API.DTOs.SubscriptionPeriod;
using AMAPP.API.Models;
using AutoMapper;

namespace AMAPP.API.Profiles;

public class SubscriptionPeriodProfile : Profile
{
    public SubscriptionPeriodProfile()
    {
        // Mapping from Create DTO to SubscriptionPeriod model
        CreateMap<CreateSubscriptionPeriodDto, SubscriptionPeriod>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));
            // Uncomment below if DeliveryDates and ProductOffers are required
            /*
            .ForMember(dest => dest.DeliveryDates, opt => opt.MapFrom(src =>
                src.SelectedProductOfferIds.Select(id => new SelectedProductOffer { Id = id }).ToList()))
            .ForMember(dest => dest.ProductOffers, opt => opt.MapFrom(src =>
                src.ProductOfferIds.Select(id => new ProductOffer { Id = id }).ToList()));
            */

        // Mapping from Update DTO to SubscriptionPeriod model
        CreateMap<SubscriptionPeriodDto, SubscriptionPeriod>()
            .ForMember(dest => dest.Name, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Name)))
            .ForMember(dest => dest.StartDate, opt => opt.Condition(src => src.StartDate != default(DateTime)))
            .ForMember(dest => dest.EndDate, opt => opt.Condition(src => src.EndDate != default(DateTime)));

        // Mapping from SubscriptionPeriod model to Response DTO
        CreateMap<SubscriptionPeriod, ResponseSubscriptionPeriodDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));
    }
}
