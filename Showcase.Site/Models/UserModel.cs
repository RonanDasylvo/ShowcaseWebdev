using System.ComponentModel.DataAnnotations.Schema;

namespace Showcase.Models;

[Table("Users")]
public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Role { get; set; } = 0;
}