using AMAPP.API.DTOs.ProductOffer;
using AMAPP.API.DTOs.SelectedProductOffer;

namespace AMAPP.API.DTOs.SubscriptionPeriod;

public class ResponseSubscriptionPeriodPlanDto
{
    public ResponseSubscriptionPeriodDto SubscriptionPeriod { get; set; }
    public List<ResponseSelectedProductOfferDto> SelectedProductOffers { get; set; } = new ();
    public List<ResponseProductOfferDto> ProductOffers { get; set; } = new ();
}