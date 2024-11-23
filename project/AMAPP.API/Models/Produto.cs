namespace AMAPP.API.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoBreve { get; set; }
        public string Fotografia { get; set; }
        public double PrecoReferencia { get; set; }
        public int UnidadesEntrega { get; set; }

        // Relacionamento com TipoProduto
        public int TipoProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }

        // Relacionamento muitos-para-muitos
        public List<ProdutoCompostoProduto> ProdutoCompostoProdutos { get; set; } = new List<ProdutoCompostoProduto>();
    }
}
