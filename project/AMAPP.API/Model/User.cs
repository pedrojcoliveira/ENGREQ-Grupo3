using Microsoft.AspNetCore.Identity;

namespace AMAPP.API.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
