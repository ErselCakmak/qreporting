using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using qreporting.Helpers;
using qreporting.Models;
using qreporting.Services;

namespace qreporting.Controllers;

public class LoginController : BaseController
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger, LocalizationService localizer, CookieHelper cookieHelper) : base(localizer, cookieHelper)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<string> keysToRetrieve = new List<string>
        {
            "Welcome", "Login", "Email", "Password", "Support",
            "ForgotPassword", "RememberMe", "SelectLanguage"
        };

        LoginViewModel viewModel = new LoginViewModel
        {
            LocalizedValues = GetSubsetLocalizedValues(keysToRetrieve),
            ThemeMode = GetThemeModeFromCookie(),
            SelectedCulture = GetCurrentCultureName()
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Login()
    {
        return RedirectToAction("Index", "Dashboard");
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