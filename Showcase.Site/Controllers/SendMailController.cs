using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Showcase.Attributes;
using Showcase.Models;

namespace Showcase.Controllers;

[ApiController]
[Route("[controller]")]
public partial class SendMailController : ControllerBase
{
    [HttpPost]
    public IActionResult SendMail([FromBody] MailDataModel data)
    {
        if (!ModelState.IsValid || !EmailRegex().IsMatch(data.MailSender))
            return BadRequest(new { success = false, message = "De opgestuurde data is incorrect ingevuld." });

        if (!int.TryParse(data.CaptchaValue, out int val))
            return BadRequest(new { success = false, message = "De captcha is incorrect ingevuld." });

        if (val != 9)
            return BadRequest(new { success = false, message = "De captcha is incorrect ingevuld." });

        try
        {
            using SmtpClient mailClient = new();
            SmtpClient client = new(MailSettings.Host, MailSettings.Port)
            {
                Credentials = new NetworkCredential(MailSettings.UserName, MailSettings.Password),
                EnableSsl = true
            };

            client.Send(data.MailSender, MailSettings.EmailTo, data.MailSubject, data.MailBody);
        }
        catch (ArgumentException)
        {
            return BadRequest(new { success = false, message = "De opgestuurde data is incorrect ingevuld." });
        }

        return Ok(new { success = true, message = "Bericht succesvol verzonden!" });
    }

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();
}