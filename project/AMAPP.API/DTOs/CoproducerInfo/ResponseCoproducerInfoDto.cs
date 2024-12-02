using AMAPP.API.DTOs.CheckingAccount;

namespace AMAPP.API.DTOs.CoproducerInfo;

public class ResponseCoproducerInfoDto
{ 
        public int Id { get; set; }

        // Relacionamento com ApplicationUser
        public string UserId { get; set; } // considerar substituir por um ResponseApplicationUserDto
        
        public ResponseCheckingAccountDto? CheckingAccount { get; set; }   
}