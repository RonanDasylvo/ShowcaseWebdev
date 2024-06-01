using Microsoft.AspNetCore.Mvc;
using Showcase.Api.Interfaces;
using Showcase.Api.Models.Models;

namespace Showcase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MailController(IMailService mailService) : ControllerBase
{
    [HttpPost]
    [Route("SendMail")]
    public bool SendMail(MailDataModel data)
        => mailService.SendMail(data);
}