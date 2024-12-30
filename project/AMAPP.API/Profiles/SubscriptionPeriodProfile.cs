using AMAPP.API.DTOs;
using AMAPP.API.DTOs.SubscriptionPeriod;
using AMAPP.API.Models;
using AutoMapper;

namespace AMAPP.API.Profiles
{
    public class SubscriptionPeriodProfile : Profile
    {
        public SubscriptionPeriodProfile()
        {
            // Mapping from DTO to SubscriptionPeriod model
            CreateMap<SubscriptionPeriodDto, SubscriptionPeriod>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.DeliveryDates, opt => opt.MapFrom(src => src.Dates.Select(dd => new DeliveryDate { Date = dd }).ToList()))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration.ToString()));

            // Mapping from SubscriptionPeriod model to DTO
            CreateMap<SubscriptionPeriod, SubscriptionPeriodDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Dates, opt => opt.MapFrom(src => src.DeliveryDates.Select(dd => dd.Date).ToList()))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom<SubscriptionDurationResolver>());

            // Mapping from SubscriptionPeriod to Response DTO
            CreateMap<SubscriptionPeriod, ResponseSubscriptionPeriodDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.DeliveryDates, opt => opt.MapFrom(src => src.DeliveryDates.Select(dd => dd.Date).ToList()))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom<SubscriptionDurationResolver>());
        }
    }

    // Custom resolver to map SubscriptionDuration enum
    public class SubscriptionDurationResolver : IValueResolver<SubscriptionPeriod, SubscriptionPeriodDto, SubscriptionDuration>,
                                                 IValueResolver<SubscriptionPeriod, ResponseSubscriptionPeriodDto, SubscriptionDuration>
    {
        public SubscriptionDuration Resolve(SubscriptionPeriod source, SubscriptionPeriodDto destination, SubscriptionDuration destMember, ResolutionContext context)
        {
            return Enum.TryParse<SubscriptionDuration>(source.Duration, true, out var result) ? result : default;
        }

        public SubscriptionDuration Resolve(SubscriptionPeriod source, ResponseSubscriptionPeriodDto destination, SubscriptionDuration destMember, ResolutionContext context)
        {
            return Enum.TryParse<SubscriptionDuration>(source.Duration, true, out var result) ? result : default;
        }
    }
}
