using AMAPP.API.DTOs.Product;
using AMAPP.API.DTOs.SelectedDeliveryDate;
using AMAPP.API.Models;

namespace AMAPP.API.DTOs.ProductOffer;

public class ResponseProductOfferDto
{ 
        public int Id { get; set; }
        public int PeriodSubscriptionId { get; set; }
        public ProductDto? Product { get; set; }
        public List<ResponseSelectedDeliveryDateDto> SelectedDeliveryDates { get; set; } = new ();
}