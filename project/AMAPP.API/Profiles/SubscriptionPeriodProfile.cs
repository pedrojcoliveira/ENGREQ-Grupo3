using AMAPP.API.DTOs;
using AMAPP.API.DTOs.DeliveryDate;
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
            CreateMap<CreateSubscriptionPeriodDto, SubscriptionPeriod>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                //.ForMember(dest => dest.DeliveryDates, opt => opt.MapFrom(src => src.Dates.Select(dd => new DeliveryDate { Date = dd.Date, ResourceStatus = dd.ResourceStatus}).ToList()))
                .ForMember(dest => dest.DeliveryDates, opt => opt.MapFrom(src => src.Dates))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));
            
            CreateMap<SubscriptionPeriodDto, SubscriptionPeriod>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.DeliveryDates, opt => opt.MapFrom(src => src.Dates.Select(dd => new DeliveryDate { Date = dd.Date }).ToList()))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));
        
        // Mapping from SubscriptionPeriod model to Response DTO
        CreateMap<SubscriptionPeriod, ResponseSubscriptionPeriodDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            //.ForMember(dest => dest.DeliveryDates, opt => opt.MapFrom(src => src.DeliveryDates.Select(dd => dd.Date).ToList()))
            .ForMember(dest => dest.Dates, opt => opt.MapFrom(src => src.DeliveryDates  )  )
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.ResourceStatus, opt => opt.MapFrom(src => src.ResourceStatus));
            
            
            
            CreateMap<CreateDeliveryDateDto, DeliveryDate>();
            CreateMap<DeliveryDate, ResponseDeliveryDateDto>();
            CreateMap<DeliveryDateDto, DeliveryDate>();
        }
        
    }
}
