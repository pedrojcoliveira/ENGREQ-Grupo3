using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.Models
{
    // Conta corrente
    public class CheckingAccount
    {
        public int Id { get; set; }

        // Relacionamento com Coprodutor
        public CoproducerInfo Coproducer { get; set; }

        public double Balance { get; set; }
    }
}
