using Showcase.Api.Models;

namespace Showcase.Api.Interfaces;

public interface IMailService
{
    bool SendMail(MailDataModel data);

}