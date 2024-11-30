using AMAPP.API.DTOs.SubscriptionPeriod;
using AMAPP.API.Models;
using AutoMapper;

namespace AMAPP.API.Profiles;

public class SubscriptionPeriodProfile : Profile
{
    public SubscriptionPeriodProfile()
    {
        CreateMap<(CreateSubscriptionPeriodDto, List<ProductOffer>, List<SelectedProductOffer>), SubscriptionPeriod>()
            .ForMember(dest => dest.DeliveryDates, opt => opt.MapFrom(src => src.Item3))
            .ForMember(dest => dest.ProductOffers, opt => opt.MapFrom(src => src.Item2))
            .ForMember(dest => dest, opt => opt.MapFrom(src => src.Item1));

    }
}