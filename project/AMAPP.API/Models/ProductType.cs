using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMAPP.API.Models
{
    public class ProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Ex.: 1 (Simples), 2 (Composto)
        public string Name { get; set; } // Ex.: "Simples", "Composto"
        public string Description { get; set; } // Opcional: "Produto individual sem composição"
    }
}
