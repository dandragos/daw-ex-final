using CarReviewApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AccountController : Controller
{
    [HttpGet]
    public ActionResult Login()
    {
        Users user = new Users();
        return View(user);
    }

    [HttpPost]
    public async Task<ActionResult> Login(Users user)
    {
        var usrs = new Users();
        var result = usrs.GetUsers().FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        if (result != null)
        {
            var userClaims = new List<Claim>()
                        {
                        new Claim(ClaimTypes.Name, result.Username),
                        new Claim(ClaimTypes.Role, result.Role),
                        };

            var identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

            var userPrincipal = new ClaimsPrincipal(new[] { identity });

            await HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index", "Home");
        }

        return View(user);
    }

    public ActionResult AccessDenied()
    {
        return View();
    }

    public async Task<ActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", new Users());
    }
}