using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Services.Helper.Interface;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mime;

namespace LearningCentre.Core.Services.Helper.Implementation
{
    public class MailServices : IMailServices
    {
        private readonly IConfiguration _configuration;
        private readonly ISendGridClient _sendGridClient;

        public MailServices(IConfiguration configuration, ISendGridClient sendGridClient)
        {
            _configuration = configuration;
            _sendGridClient = sendGridClient;
        }

        public void SendEmail(EmailRequestModel request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;

            var builder = new BodyBuilder();
            byte[] fileBytes;
            if (request.Attachments != null)
            {
                var file = request.Attachments;
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    //email.Attachments = file;

                    builder.Attachments.Add(file.FileName, fileBytes, MimeKit.ContentType.Parse(MediaTypeNames.Image.Jpeg));
                }
            }
            builder.TextBody = request.Body;
            email.Body = builder.ToMessageBody();

            // email.Body = builder.TextBody. ( new TextPart(TextFormat.Html) { Text = request.Body };
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUsername").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public async Task<string> SendGridMailSend(string ToEmail, string htmlcontent, string planeContent, string subject)
        {





            string fromEmail = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromEmail");

            string fromName = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromName");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = subject,
                HtmlContent = htmlcontent,
               
            };
            msg.AddTo(ToEmail);

            var response = await _sendGridClient.SendEmailAsync(msg);
            string message = response.IsSuccessStatusCode ? "Email Send Successfully" :
            "Email Sending Failed";
            return message;
        }

       
    }
}