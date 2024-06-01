using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Showcase.Api.Interfaces;
using Showcase.Api.Models;
using Showcase.Api.Models.Models;

namespace Showcase.Api.Services;

public class MailService(IOptions<MailSettings> mailSettingsOptions) : IMailService
{
    private readonly MailSettings _mailSettings = mailSettingsOptions.Value;

    public bool SendMail(MailDataModel data)
    {
        try
        {
            using MimeMessage emailMessage = new();

            MailboxAddress emailFrom = new(_mailSettings.SenderName, _mailSettings.SenderEmail);
            emailMessage.From.Add(emailFrom);
            MailboxAddress emailTo = new(data.EmailToName, data.EmailToId);
            emailMessage.To.Add(emailTo);

            emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
            emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

            emailMessage.Subject = data.EmailSubject;

            BodyBuilder emailBodyBuilder = new BodyBuilder
            {
                TextBody = data.EmailBody
            };

            emailMessage.Body = emailBodyBuilder.ToMessageBody();
            //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
            using SmtpClient mailClient = new();

            mailClient.Connect(_mailSettings.Server, _mailSettings.Port,
                MailKit.Security.SecureSocketOptions.StartTls);
            mailClient.Authenticate(_mailSettings.UserName, _mailSettings.Password);
            mailClient.Send(emailMessage);
            mailClient.Disconnect(true);

            return true;
        }
        catch (Exception ex)
        {
            // Exception Details
            return false;
        }
    }
}