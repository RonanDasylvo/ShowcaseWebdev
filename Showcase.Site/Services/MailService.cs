﻿using System.Net;
using System.Net.Mail;
using Showcase.Interfaces;
using Showcase.Models;
using Showcase.Attributes;

namespace Showcase.Services;

public class MailService : IMailService
{
    public bool SendMail(MailData mailData)
    {
        try
        {
            using SmtpClient mailClient = new();

            SmtpClient client = new(MailSettings.Host, MailSettings.Port)
            {
                Credentials = new NetworkCredential(MailSettings.UserName, MailSettings.Password),
                EnableSsl = true
            };
            client.Send(mailData.EmailFromId, MailSettings.EmailTo, mailData.EmailSubject, mailData.EmailBody);
            Console.WriteLine("Sent");

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}