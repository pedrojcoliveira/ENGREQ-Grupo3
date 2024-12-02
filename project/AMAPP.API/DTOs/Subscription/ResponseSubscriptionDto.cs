using AMAPP.API.DTOs.CoproducerInfo;
using AMAPP.API.DTOs.ProductOffer;
using AMAPP.API.DTOs.SelectedProductOffer;
using AMAPP.API.Models;

namespace AMAPP.API.DTOs.Subscription;

public class ResponseSubscriptionDto
{ 
        public int Id { get; set; }
        
        public ResponseCoproducerInfoDto? CoproducerInfo { get; set; }
        
        public int SubscriptionPeriodId { get; set; } // considerar tirar
        
        //public List<ResponseSelectedProductOfferDto> SelectedProducts { get; set; } = new (); //talvez lista de ints para é recursivo como esta
}