using WebParking.Services.EmailServices;

namespace WebParking.Service.Services
{
    public interface IEmailSender
    {
        /// <summary>
        /// Отправка сообщения на почту
        /// </summary>
        /// <param name="message"></param>
        void SendEmail(Message message);
    }
}
