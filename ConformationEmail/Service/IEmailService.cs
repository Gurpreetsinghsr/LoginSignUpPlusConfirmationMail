using autoMail.Models;
using System.Threading.Tasks;

namespace autoMail.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);

        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
    }
}