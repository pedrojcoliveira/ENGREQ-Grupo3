using AutoMapper;
using AMAPP.API.DTOs.SelectedProductOffer;
using AMAPP.API.Models;

namespace AMAPP.API.Profiles
{
    public class SelectedProductOfferProfile : Profile
    {
        public SelectedProductOfferProfile()
        {
            CreateMap<SelectedProductOffer, ResponseSelectedProductOfferDto>()
                .ForMember(dest => dest.ResponseSubscriptionPaymentDto, opt => opt.MapFrom(src => src.SubscriptionPayments));

            CreateMap<SelectedProductOfferDto, SelectedProductOffer>();
            
            
            CreateMap<CreateSelectedProductOfferDto, SelectedProductOffer>()
                .ForMember(dest => dest.SubscriptionPayments, opt => opt.MapFrom(src => src.CreateSubscriptionPaymentsDto))
                .AfterMap((src, dest) =>
                {
                    foreach (var payment in dest.SubscriptionPayments)
                    {
                        payment.SubscriptionId = src.SubscriptionId;
                    }
                });
            
         

        }
        
    }
}