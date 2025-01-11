using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMAPP.API.Models
{
    public class SubscriptionPeriod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public SubscriptionDuration Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DeliveryDate> DeliveryDates { get; set; } = new ();
        public List<ProductOffer> ProductOffers { get; set; } = new ();
        public ICollection<Subscription> Subscriptions { get; set; }
        public ResourceStatus ResourceStatus { get; set; }
    }
}
