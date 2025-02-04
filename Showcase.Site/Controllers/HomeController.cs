using Microsoft.AspNetCore.Mvc;
using Showcase.Models;
using System.Diagnostics;

namespace Showcase.Controllers;

public class HomeController : Controller
{
    // ILogger<HomeController> logger
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}