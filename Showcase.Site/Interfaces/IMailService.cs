using Showcase.Models;

namespace Showcase.Interfaces;

public interface IMailService
{
    bool SendMail(MailData mailData);
}