using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using qreporting.Models;
using qreporting.Services;

namespace qreporting.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly LanguageService _localizer;

    public LoginController(ILogger<LoginController> logger, LanguageService localizer)
    {
        _logger = logger;
        _localizer = localizer;
    }

    public IActionResult Index()
    {
        string themeMode = GetThemeModeFromCookie();
        var keysToRetrieve = new[] { "Welcome", "Login", "Email", "Password", "Support", "ForgotPassword", "RememberMe", "SelectLanguage" };
        ViewBag.LocalizedValues = _localizer.GetSubsetLocalizedValues(keysToRetrieve);
        ViewBag.ThemeMode = themeMode;
        ViewBag.SelectedCulture = Thread.CurrentThread.CurrentCulture.Name;
        return View();
    }

    private string GetThemeModeFromCookie()
    {
        return HttpContext.Request.Cookies["themeMode"] ?? "light";
    }

    [HttpPost]
    public IActionResult Login()
    {
        return RedirectToAction("Index", "Dashboard");
    }


    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
        _localizer.GetAllLocalizedValues();

        return Redirect(Request.Headers["Referer"].ToString());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

