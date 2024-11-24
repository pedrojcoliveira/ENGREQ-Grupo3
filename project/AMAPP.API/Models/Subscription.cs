namespace AMAPP.API.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        // Relacionamento com Coprodutor
        public int CoproducerId { get; set; }
        public CoproducerInfo Coproducer { get; set; }

        // Relacionamento com OfertaProduto
        public int ProductOfferId { get; set; }
        public ProductOffer ProductOffer { get; set; }

        // Produtos selecionados pelo coprodutor 
        public List<SelectedProduct> SelectedProducts { get; set; } = new List<SelectedProduct>();


        public string PaymentMethod { get; set; }
        public int NumberOfInstallments { get; set; }
    }
}
