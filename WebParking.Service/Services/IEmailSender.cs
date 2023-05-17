using WebParking.Services.EmailServices;

namespace WebParking.Service.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
