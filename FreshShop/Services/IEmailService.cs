using FreshShop.Models;
using System.Threading.Tasks;

namespace FreshShop.Services
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);

        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);

        Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions); 
    }
}