using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMAPP.API.Models
{
    // Conta corrente
    public class CheckingAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Relacionamento com Coprodutor
        public CoproducerInfo Coproducer { get; set; }

        public double Balance { get; set; }
    }
}
