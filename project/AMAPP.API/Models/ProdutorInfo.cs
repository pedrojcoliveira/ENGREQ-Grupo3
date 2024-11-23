namespace AMAPP.API.Models
{
    public class ProdutorInfo
    {
        public long Id { get; set; }

        // Relacionamento com ApplicationUser
        public string UserId { get; set; }
        public User User { get; set; }

        // Propriedade específica
        public List<Produto> CatalogoProdutos { get; set; } = new List<Produto>();
    }
}
