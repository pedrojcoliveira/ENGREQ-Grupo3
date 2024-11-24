namespace AMAPP.API.Models
{
    public class ProductDelivery
    {
        public int Id { get; set; }

        // Produto entregue
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Relacionamento com Subscricao
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        // Quantidades
        public int QuantitySubscribed { get; set; }
        public int QuantityDelivered { get; set; }
    }
}
