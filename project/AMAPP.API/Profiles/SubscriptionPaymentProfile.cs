using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Models;
using AutoMapper;

namespace AMAPP.API.Profiles
{
    public class SubscriptionPaymentProfile : Profile
    {
        public SubscriptionPaymentProfile()
        {
            CreateMap<CreateSubscriptionPaymentDto, SubscriptionPayment>();
            CreateMap<SubscriptionPaymentDto, SubscriptionPayment>();
            CreateMap<SubscriptionPayment, ResponseSubscriptionPaymentDto>();
            CreateMap<UpdateSubscriptionPaymentDto, ResponseSubscriptionPaymentDto>();
        }
    }
}