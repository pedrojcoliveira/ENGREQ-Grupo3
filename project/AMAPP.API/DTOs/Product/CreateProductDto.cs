using AMAPP.API.Models;
using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.DTOs.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public double ReferencePrice { get; set; }
        [Required]
        public string DeliveryUnit { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        public IFormFile? Photo { get; set; } // The uploaded image file

    }
}
