using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.Models
{
    public class CoproducerInfo
    {
        public int Id { get; set; }

        // Relacionamento com ApplicationUser
        public string UserId { get; set; }
        public User User { get; set; }

        // Propriedade específica
        public CheckingAccount CheckingAccount { get; set; }
    }
}
