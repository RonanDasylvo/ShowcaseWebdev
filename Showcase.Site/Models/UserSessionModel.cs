using Microsoft.AspNetCore.Mvc.RazorPages;
using Showcase.Attributes;

namespace Showcase.Models;

public class UserSessionModel : PageModel
{
    public UserModel? UserSession { get; set; }

    public void OnGet()
    {
        UserSession = HttpContext.Session.GetObjectFromJson<UserModel>("LoggedInUser");
    }
}