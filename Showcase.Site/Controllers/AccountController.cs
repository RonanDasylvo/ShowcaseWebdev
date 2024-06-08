using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Showcase.Data;

namespace Showcase.Controllers;

[ApiController]
[Route("[controller]")]
public partial class AccountController(ShowcaseDbContext db) : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult RegisterUser([FromBody] string name, string email, string password, string passwordRepeat)
    {
        return Ok(new { success = true, message = "Account is succesvol aangemaakt!" });
    }
    
    [HttpPost]
    public IActionResult LoginUser([FromBody] string email, string password)
    {
        return Ok(new { success = true, message = "Account is succesvol aangemaakt!" });
    }

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();
}