using AMAPP.API.DTOs.Subscription;
using AMAPP.API.Models;
using AutoMapper;

namespace AMAPP.API.Profiles
{
    public class SubscriptionProfile: Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionDto>();
        }
    }
}
