namespace AMAPP.API.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        // Relacionamento com Coprodutor
        public int CoproducerInfoId { get; set; }
        public CoproducerInfo CoproducerInfo { get; set; }

        // Relacionamento com OfertaProduto
        public int SubscriptionPeriodId { get; set; }
        public SubscriptionPeriod SubscriptionPeriod { get; set; }

        // Produtos selecionados pelo coprodutor 
        public List<SelectedProductOffer> SelectedProducts { get; set; } = new List<SelectedProductOffer>();

    }
}
