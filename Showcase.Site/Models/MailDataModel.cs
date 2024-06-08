using System.ComponentModel.DataAnnotations;

namespace Showcase.Models;

public class MailDataModel
{
    public string MailSender { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string MailSubject { get; set; } = string.Empty;
    
    [MaxLength(600)]
    public string MailBody { get; set; } = string.Empty;
    
    [MaxLength(9)]
    public string CaptchaValue { get; set; } = string.Empty;
}