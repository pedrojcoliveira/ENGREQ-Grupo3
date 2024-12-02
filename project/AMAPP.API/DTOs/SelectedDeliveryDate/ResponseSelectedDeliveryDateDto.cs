namespace AMAPP.API.DTOs.SelectedDeliveryDate;

public class ResponseSelectedDeliveryDateDto
{ 
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ResponseProductOfferId { get; set; } // este id como referencia o objecto pai podia ser dispensavel
}