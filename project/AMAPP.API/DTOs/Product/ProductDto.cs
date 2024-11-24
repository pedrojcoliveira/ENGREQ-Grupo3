using AMAPP.API.Models;
using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.DTOs.Produto
{
    public class ProductDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public double ReferencePrice { get; set; }
        [Required]
        public string DeliveryUnit { get; set; }
        public int ProductTypeId { get; set; } = 1;

    }
}
