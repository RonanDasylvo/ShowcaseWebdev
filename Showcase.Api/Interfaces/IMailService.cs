using Showcase.Api.Models.Models;

namespace Showcase.Api.Interfaces;

public interface IMailService
{
    bool SendMail(MailDataModel data);

}