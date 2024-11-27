namespace AMAPP.API.Models;

public class ProducerInfo
{
    public int Id { get; set; }

    // Relacionamento com ApplicationUser
    public string UserId { get; set; }
    public User User { get; set; }

    // Propriedade específica
    public List<Product> Products { get; set; } = new List<Product>();
}
