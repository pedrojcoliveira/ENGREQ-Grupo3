using AMAPP.API.DTOs.ProductOffer;
using AMAPP.API.DTOs.Subscription;

namespace AMAPP.API.DTOs.SelectedProductOffer;

public class ResponseSelectedProductOfferDto
{ 
        public int Id { get; set; }

        public DateTime DeliveryDate { get; set; }
        
        public ResponseProductOfferDto ProductOffer { get; set; } // um pouco redundante consierando que o objecto pai ja tem esta lista -> considerar trocar por lista de ids apenas
        
        public ResponseSubscriptionDto Subscription { get; set; }

        public int Quantity { get; set; }
}