using OnlineDeliveryProject.Application.DataTransfer;

namespace OnlineDeliveryProject.Application.Email
{
    public interface IEmailSender
    {
        void Send(SendEmailDto dto);
    }
}
