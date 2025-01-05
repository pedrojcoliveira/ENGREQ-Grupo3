using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AMAPP.Web.Models
{
    public class SubscriptionPeriod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Constants.SubscriptionDuration Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public List<DeliveryDate> Dates { get; set; } = new ();

        // Relacionamento com OfertaProduto
        public List<ProductOffer> ProductOffers { get; set; } = new();
    }
}
