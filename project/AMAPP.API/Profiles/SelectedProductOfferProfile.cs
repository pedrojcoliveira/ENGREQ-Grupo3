using AutoMapper;
using AMAPP.API.DTOs.SelectedProductOffer;
using AMAPP.API.Models;

namespace AMAPP.API.Profiles
{
    public class SelectedProductOfferProfile : Profile
    {
        public SelectedProductOfferProfile()
        {
            CreateMap<CreateSelectedProductOfferDto, SelectedProductOffer>()
                .ForMember(dest => dest.Payments,
                    opt => opt.MapFrom(src => src.CreateSubscriptionPaymentsDto));
                //.AfterMap((src, dest) =>
                //{
                //    foreach (var payment in dest.Payments)
                //    {
                //        payment.SubscriptionId = src.SubscriptionId;
                //    }
                //});

            CreateMap<SelectedProductOfferDto, SelectedProductOffer>()
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.SubscriptionPaymentDto));
                //.AfterMap((src, dest) =>
                //{
                //    foreach (var payment in dest.Payments)
                //    {
                //        payment.SubscriptionId = src.SubscriptionId;
                //    }
                //});

            CreateMap<SelectedProductOfferDto, SelectedProductOffer>();


            CreateMap<UpdateSelectedProductOfferQuantityDto, SelectedProductOffer>();
                //.ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
        }
    }
}