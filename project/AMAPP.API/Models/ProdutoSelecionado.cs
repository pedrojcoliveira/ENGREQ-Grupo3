namespace AMAPP.API.Models
{
    public class ProdutoSelecionado
    {
        public long Id { get; set; }

        public DateTime DataEntrega { get; set; }

        public long ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public long SubscricaoId { get; set; }
        public Subscricao Subscricao { get; set; }

        public int Quantidade { get; set; }
    }
}
