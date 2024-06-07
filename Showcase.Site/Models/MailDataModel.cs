using System.ComponentModel.DataAnnotations;

namespace Showcase.Models;

public class MailDataModel
{
    public string MailSender { get; set; }
    [MaxLength(200)]
    public string MailSubject { get; set; }
    [MaxLength(600)]
    public string MailBody { get; set; }
    [MaxLength(9)]
    public string CaptchaValue { get; set; }
}