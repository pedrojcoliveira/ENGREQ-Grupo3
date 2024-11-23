namespace AMAPP.API.Models
{
    public class ProdutoCompostoProduto
    {
        public long ProdutoCompostoId { get; set; }
        public Produto ProdutoComposto { get; set; }

        public long ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
