using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMAPP.API.Models
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Relacionamento com Coprodutor
        public int CoproducerInfoId { get; set; }
        public CoproducerInfo CoproducerInfo { get; set; }

        // Relacionamento com OfertaProduto
        public int SubscriptionPeriodId { get; set; }
        public SubscriptionPeriod SubscriptionPeriod { get; set; }

        // Produtos selecionados pelo coprodutor 
        public List<SelectedProductOffer> SelectedProductOffers { get; set; } = new ();

    }
}
