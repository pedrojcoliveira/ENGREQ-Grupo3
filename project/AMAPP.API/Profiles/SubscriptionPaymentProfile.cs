using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Models;
using AutoMapper;

namespace AMAPP.API.Profiles
{
    public class SubscriptionPaymentProfile : Profile
    {
        public SubscriptionPaymentProfile()
        {
            CreateMap<CreateSubscriptionPaymentDto, Payment>();
            CreateMap<SubscriptionPaymentDto, Payment>();
            CreateMap<Payment, ResponseSubscriptionPaymentDto>();
            CreateMap<UpdateSubscriptionPaymentDto, ResponseSubscriptionPaymentDto>();
        }
    }
}