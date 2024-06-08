using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Controllers;

[ApiController]
[Route("[controller]")]
public partial class ManageAccountController(IAccountService accountService) : ControllerBase
{
    private const string LoggedInName = "";
    private const string LoggedInEmail = "";
    private const string LoggedInRole = "";

    [HttpPost]
    [Route("Login")]
    public IActionResult LoginUser([FromBody] UserModel entity)
    {
        UserModel? user = accountService.GetByEmail(entity.Email);

        if (user == null)
            return BadRequest(new { success = false, message = "Gebruiker bestaat niet." });

        if (user.Password != entity.Password)
            return BadRequest(new { success = false, message = "Incorrecte inloggevens." });

        HttpContext.Session.SetString(LoggedInName, user.Username);
        HttpContext.Session.SetString(LoggedInEmail, user.Email);
        HttpContext.Session.SetInt32(LoggedInRole, user.Role);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Route("Logout")]
    public IActionResult LogoutUser([FromBody] UserModel entity)
    {
        HttpContext.Session.Remove(LoggedInName);
        HttpContext.Session.Remove(LoggedInEmail);
        HttpContext.Session.Remove(LoggedInRole);

        return Ok(new { succes = true, message = "Uitloggen gelukt!" });
    }

    [HttpPost]
    [Route("Register")]
    public IActionResult RegisterUser([FromBody] UserModel entity)
    {
        if (!ModelState.IsValid || !EmailRegex().IsMatch(entity.Email))
            return BadRequest(new { success = false, message = "De opgestuurde data is incorrect ingevuld." });

        accountService.Save(new UserModel
            { Username = entity.Username, Email = entity.Email, Password = entity.Password, Role = 0 });

        return Ok(new { success = true, message = "Account is succesvol aangemaakt!" });
    }

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();
}