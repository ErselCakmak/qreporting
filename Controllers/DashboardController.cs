using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using qreporting.Services;

namespace qreporting.Controllers
{
    public class DashboardController : Controller
    {
        private readonly LanguageService _localizer;

        public DashboardController(LanguageService localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var keysToRetrieve = new[] { "Welcome", "Login", "Email", "Password", "Support", "ForgotPassword", "RememberMe", "SelectLanguage" };
            ViewBag.LocalizedValues = _localizer.GetSubsetLocalizedValues(keysToRetrieve);
            ViewBag.SelectedCulture = Thread.CurrentThread.CurrentCulture.Name;
            ViewBag.page = "Dashboard";
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.MaxValue
                });
            _localizer.GetAllLocalizedValues();

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
