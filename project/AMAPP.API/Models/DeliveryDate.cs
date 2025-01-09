using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMAPP.API.Models
{
    public class DeliveryDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int SubscriptionPeriodId { get; set; }
        
        public ResourceStatus ResourceStatus { get; set; }
        
    }
}
