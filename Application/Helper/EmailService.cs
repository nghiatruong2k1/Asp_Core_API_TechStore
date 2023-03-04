using Application.Contexts;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Application.Helper
{
    public interface IEmailService
    {
        Task<Boolean> SendEmail(EmailData data);
        Task<Boolean> SendEmail(EmailAccount email,EmailData data);
    }
    public class EmailService : IEmailService
    {
        EmailConfigs _settings = null;
        EmailAccount _email = null;
        public EmailService(IOptions<EmailConfigs> settings)
        {
            _settings = settings.Value;
            _email = new EmailAccount() { 
                Username = Environment.GetEnvironmentVariable("ASPNETCORE_MAILER_EMAIL"),
                Password = Environment.GetEnvironmentVariable("ASPNETCORE_MAILER_PASSWORD") 
            };
        }
        public async Task<Boolean> SendEmail(EmailData data)
        {
            return await SendEmail(_email, data);
        }
        public async Task<Boolean> SendEmail(EmailAccount email,EmailData data)
        {

            MimeMessage emailMessage = new MimeMessage();
            MailboxAddress emailFrom = new MailboxAddress(data.FromName, email.Username);
            emailMessage.From.Add(emailFrom);
            MailboxAddress emailTo = new MailboxAddress(data.ToName, data.ToEmail);
            emailMessage.To.Add(emailTo);
            emailMessage.Subject = data.Subject;
            BodyBuilder emailBodyBuilder = new BodyBuilder();


            emailBodyBuilder.HtmlBody = data.Body;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = data.Body };


            SmtpClient emailClient = new SmtpClient();

            await emailClient.ConnectAsync(_settings.Host, _settings.Port, _settings.UseSSL);
            await emailClient.AuthenticateAsync(email.Username, email.Password);
            await emailClient.SendAsync(emailMessage);
            await emailClient.DisconnectAsync (true);
            emailClient.Dispose();

            return true;

        }
    }
}
