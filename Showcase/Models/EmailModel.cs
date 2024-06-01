namespace Showcase.Models;

public class EmailModel
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public int PhoneNumber { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}