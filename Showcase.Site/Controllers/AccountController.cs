using Microsoft.AspNetCore.Mvc;
using Showcase.Interfaces;

namespace Showcase.Controllers;

public class AccountController(IAccountService accountService) : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
}