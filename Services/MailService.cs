using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MiniHospitalProject.Configuration;
using MiniHospitalProject.Models;
//using System.Net;


namespace MiniHospitalProject.Services
{
    public class MailService : IMailService
    {
        private readonly EmailSettings _settings;
        public MailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public bool SendEmail(MailContent messagebody)
        {
            try
            {
                MimeMessage mail = new MimeMessage();
                mail.From.Add(MailboxAddress.Parse(_settings.FromEmailAddress));
                mail.To.Add(MailboxAddress.Parse(messagebody.ToEmailAddress));
                mail.Subject = messagebody.SubjectEmail;
                ///will use another class to email compose
                BodyBuilder body = new BodyBuilder();
                body.HtmlBody = messagebody.bodyEmail;
                ///for attachments
                foreach (var file in messagebody.attachement)
                {///to conver attachemnt to byte array
                    byte[] arr;
                    ///memory stream hold byte data in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.CopyTo(ms);///copy file to memory 
                        arr = ms.ToArray();
                    }///final step add attachement
                    body.Attachments.Add(file.FileName, arr, ContentType.Parse(file.ContentType));

                }
                ///body builder ki clASS just email body ke liye use karrty hen 
                ///aur use again mail ki class main pass karty dete hen
                mail.Body = body.ToMessageBody();
                ///smtp
                using (SmtpClient client = new SmtpClient())
                {
                    // client.ServerCertificateValidationCallback=client.ServerCertificateValidationCallback;
                    client.Connect(_settings.HOST, _settings.PORT, SecureSocketOptions.StartTls);
                    client.Authenticate(_settings.FromEmailAddress, _settings.Password);
                    client.Send(mail);

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
