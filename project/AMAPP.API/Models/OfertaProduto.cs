namespace AMAPP.API.Models
{
    public class OfertaProduto
    {
        public long Id { get; set; }

        // Relacionamento com PeriodoSubscricao
        public long PeriodoSubscricaoId { get; set; }
        public PeriodoSubscricao PeriodoSubscricao { get; set; }

        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public List<DateTime> DatasEntrega { get; set; } = new List<DateTime>();

        public string FormaPagamento { get; set; } // Ex: "Integral", "Fracionado"
        public int NumeroParcelas { get; set; }
    }
}
