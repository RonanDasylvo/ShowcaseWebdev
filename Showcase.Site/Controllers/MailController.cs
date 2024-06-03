using Microsoft.AspNetCore.Mvc;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Controllers;

[ApiController]
[Route("[controller]")]
public class MailController(IMailService mailService) : ControllerBase
{
    [HttpPost]
    [Route("SendMail")]
    public bool SendMail(MailDataModel data) => mailService.SendMail(data);
}