using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.Models
{
    public class ProductType
    {
        public int Id { get; set; } // Ex.: 1 (Simples), 2 (Composto)
        public string Name { get; set; } // Ex.: "Simples", "Composto"
        public string Description { get; set; } // Opcional: "Produto individual sem composição"
    }
}
