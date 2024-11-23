namespace AMAPP.API.Models
{
    public class PeriodoSubscricao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public List<DateTime> DatasEntregas { get; set; } = new List<DateTime>();

        // Relacionamento com OfertaProduto
        public List<OfertaProduto> OfertasProdutos { get; set; } = new List<OfertaProduto>();
    }
}
