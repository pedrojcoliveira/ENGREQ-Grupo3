namespace AMAPP.API.Models
{
    public class EntregaProduto
    {
        public long Id { get; set; }

        // Produto entregue
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; }

        // Relacionamento com Subscricao
        public long SubscricaoId { get; set; }
        public Subscricao Subscricao { get; set; }

        // Quantidades
        public int QuantidadeSubscrita { get; set; }
        public int QuantidadeEntregue { get; set; }
    }
}
