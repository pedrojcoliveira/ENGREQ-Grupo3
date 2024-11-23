using AMAPP.API.Models;
using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.DTOs.Produto
{
    public class ProdutoDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string DescricaoBreve { get; set; }
        [Required]
        public string Fotografia { get; set; }
        [Required]
        public double PrecoReferencia { get; set; }
        [Required]
        public int UnidadesEntrega { get; set; }
        public int TipoProdutoId { get; set; } = 1;

    }
}
