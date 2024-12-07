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
    
            CreateMap<SubscriptionPeriodDto, SubscriptionPeriod>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));
            
        
        // Mapping from SubscriptionPeriod model to Response DTO
        CreateMap<SubscriptionPeriod, ResponseSubscriptionPeriodDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

    }
}
