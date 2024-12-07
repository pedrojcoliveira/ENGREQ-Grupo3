using System.ComponentModel.DataAnnotations;

namespace AMAPP.Web.Models
{
    public class Product
    {
        public int? Id { get; set; }

        //[Required(ErrorMessage = "O nome é obrigatório.")]
        //[StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]? Photo { get; set; }

        //[Required(ErrorMessage = "O preço de referência é obrigatório.")]
        //[RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Preço inválido.")]
        public double ReferencePrice { get; set; }
        public string DeliveryUnit { get; set; }

        //[Required(ErrorMessage = "O tipo de produto é obrigatório.")]
        public int ProductTypeId { get; set; }
        public string? PhotoBase64 { get; set; }

    }
}
