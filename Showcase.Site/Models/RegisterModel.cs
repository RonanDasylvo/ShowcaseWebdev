using System.ComponentModel.DataAnnotations;

namespace Showcase.Models;

public class RegisterModel
{
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Password { get; set; } = string.Empty;
}