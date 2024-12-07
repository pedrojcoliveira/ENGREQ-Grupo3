using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.Models
{
    public class ProductOffer
    {
        public int Id { get; set; }

        // Relacionamento com PeriodoSubscricao
        public int PeriodSubscriptionId { get; set; }
        public SubscriptionPeriod PeriodSubscription { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public List<SelectedDeliveryDate> SelectedDeliveryDates { get; set; } = new ();

        //public string PaymentMethod { get; set; } // Ex: "MBway", "TransferenciaMultibanco"
        //public string PaymentMode { get; set; } // Ex: "Integral", "Fracionado"
    }
}
