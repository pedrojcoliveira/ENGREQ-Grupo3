namespace AMAPP.API.Models
{
    public class ContaCorrente
    {
        public long Id { get; set; }

        // Relacionamento com Coprodutor
        public CoprodutorInfo Coprodutor { get; set; }

        public double Saldo { get; set; }
    }
}
