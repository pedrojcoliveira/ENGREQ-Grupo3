using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMAPP.API.Models
{
    public class CoproducerInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Relacionamento com ApplicationUser
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }

        // Propriedade específica
        public CheckingAccount CheckingAccount { get; set; }


    }
}
