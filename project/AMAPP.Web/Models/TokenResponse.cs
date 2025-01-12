namespace AMAPP.API.DTOs.Auth
{
    public class TokenResponse
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
