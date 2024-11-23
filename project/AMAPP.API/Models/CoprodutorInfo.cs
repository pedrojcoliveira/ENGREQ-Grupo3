namespace AMAPP.API.Models
{
    public class CoprodutorInfo
    {
        public long Id { get; set; }

        // Relacionamento com ApplicationUser
        public string UserId { get; set; }
        public User User { get; set; }

        // Propriedade específica
        public ContaCorrente ContaCorrente { get; set; }
    }
}
