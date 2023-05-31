using LearningCentre.Core.Domain.RequestModel;

namespace LearningCentre.Core.Services.Helper.Interface
{
    public interface IMailServices
    {
        void SendEmail(EmailRequestModel request);

       

        Task<string> SendGridMailSend(string ToEmail, string htmlcontent, string plaincontent, string subject);

        //oid SendEmail(string To, string Body, string Subject);
        //void MailSendWithAttachment(byte[] file, string ToEmail, string htmlcontent, string plaincontent, string subject, string filename);
    }
}