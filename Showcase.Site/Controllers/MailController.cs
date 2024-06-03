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
    public bool SendMail(MailData mailData) => mailService.SendMail(mailData);
}