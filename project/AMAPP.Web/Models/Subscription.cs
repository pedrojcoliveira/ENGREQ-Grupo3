namespace AMAPP.Web.Models
{
    public class SubscriptionViewModel
    {
        // Propriedades para Listagem
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProductOfferId { get; set; }
        public int SubscriptionId { get; set; }
        public int Quantity { get; set; }
        public List<SubscriptionPaymentViewModel> Payments { get; set; }

        // Propriedades para Criação
        public List<CreateSubscriptionPaymentViewModel> CreateSubscriptionPayments { get; set; }
    }

    public class SubscriptionPaymentViewModel
    {
        public int SelectedProductOfferId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentStatus { get; set; }
    }

    public class CreateSubscriptionPaymentViewModel
    {
        public int SelectedProductOfferId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}
