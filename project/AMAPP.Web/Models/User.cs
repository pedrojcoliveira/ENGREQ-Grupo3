namespace AMAPP.Web.Models
{
    public class User
    {
        public int Id { get; set; } // Identificador único do utilizador
        public string Name { get; set; } // Nome do utilizador
        public string Email { get; set; } // Email para login
        public string Password { get; set; } // Palavra-passe
        public UserType Role { get; set; } // Tipo de utilizador
    }

    public enum UserType
    {
        Producer,    // Produtor
        CoProducer,  // Co-Produtor
        Manager      // Gestor da AMAP
    }
}
