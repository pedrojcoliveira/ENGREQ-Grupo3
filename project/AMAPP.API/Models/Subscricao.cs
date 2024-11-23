namespace AMAPP.API.Models
{
    public class Subscricao
    {
        public long Id { get; set; }

        // Relacionamento com Coprodutor
        public long CoprodutorId { get; set; }
        public CoprodutorInfo Coprodutor { get; set; }

        // Relacionamento com OfertaProduto
        public long OfertaProdutoId { get; set; }
        public OfertaProduto OfertaProduto { get; set; }

        // Produtos selecionados pelo coprodutor 
        public List<ProdutoSelecionado> ProdutosSelecionados { get; set; } = new List<ProdutoSelecionado>();


        public string FormaPagamento { get; set; }
        public int NumeroParcelas { get; set; }
    }
}
