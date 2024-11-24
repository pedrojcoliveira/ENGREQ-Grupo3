namespace AMAPP.API.Models
{
    public class ProductOffer
    {
        public int Id { get; set; }

        // Relacionamento com PeriodoSubscricao
        public int PeriodSubscriptionId { get; set; }
        public SubscriptionPeriod PeriodSubscription { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public List<DateTime> DeliveryDates { get; set; } = new List<DateTime>();

        public string PaymentMethod { get; set; } // Ex: "Integral", "Fracionado"
        public int NumberOfInstallments { get; set; } // Número de parcelas
    }
}
