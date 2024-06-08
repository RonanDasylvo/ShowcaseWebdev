using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Showcase.Models;

[Table("Users")]
public class UserModel
{
    public int Id { get; init; }
    
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Password { get; set; } = string.Empty;
    
    public int Role { get; init; }
}