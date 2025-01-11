using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AMAPP.API.Constants;

namespace AMAPP.API.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]? Photo { get; set; }
        public double ReferencePrice { get; set; }
        public string DeliveryUnit { get; set; }

        // Relacionamento com TipoProduto
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        // Relacionamento muitos-para-muitos
        public List<CompoundProductProduct> CompoundProductProduct { get; set; } = new List<CompoundProductProduct>();

        public List<ProductOffer> ProductOffers { get; set; }

        // Relacionamento com Producer
        public int ProducerInfoId { get; set; } // Foreign key
        public ProducerInfo ProducerInfo { get; set; } // Navigation property


    }
}
