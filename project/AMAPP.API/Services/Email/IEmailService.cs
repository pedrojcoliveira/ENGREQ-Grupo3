using AMAPP.API.DTOs;

namespace AMAPP.API.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(MessageDto message);
    }
}
