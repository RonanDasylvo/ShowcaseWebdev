using Microsoft.AspNetCore.Mvc;
using Showcase.Attributes;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Controllers;

public class AccountController(IAccountService service) : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Error = "Incorrecte gegevens in gevuld.";
            return View(model);
        }

        if (service.GetByEmail(model.Email) != null)
        {
            ViewBag.Error = "Email is al in gebruik.";
            return View(model);
        }
        
        UserModel user = new()
        {
            Username = model.Username, 
            Email = model.Email, 
            Password = model.Password, 
            Role = 0
        };
        service.Create(user);

        Login(new LoginModel { Email = user.Email, Password = user.Password});
        
        return RedirectToAction("Login", "Account");
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(LoginModel model)
    {
        if (!ModelState.IsValid) return View(model);

        UserModel? user = service.GetByEmail(model.Email);
        
        if (user == null)
        {
            ViewBag.Error = "Deze email bestaat niet.";
            return View(model);
        }
        
        if (user.Password != model.Password)
        {
            ViewBag.Error = "Inloggevens kloppen niet.";
            return View(model);
        }
            
        HttpContext.Session.SetObjectAsJson("LoggedInUser", new
        {
            user.Id, 
            user.Username,
            user.Email,
            user.Role
        });
        
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        
        return RedirectToAction("Login", "Account");
    }
}