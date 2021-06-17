using OnlineDeliveryProject.Application.DataTransfer;
using OnlineDeliveryProject.Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace OnlineDeliveryProject.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("ivan.lekic.154.17@ict.edu.rs", "pDccNVTb")
            };

            var message = new MailMessage("ivan.lekic.154.17@ict.edu.rs", dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
