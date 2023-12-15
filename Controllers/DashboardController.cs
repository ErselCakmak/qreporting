using Microsoft.AspNetCore.Mvc;
using qreporting.Helpers;
using qreporting.Services;

namespace qreporting.Controllers
{
    public class DashboardController : BaseController
    {

        public DashboardController(LocalizationService localizer, CookieHelper cookieHelper)
             : base(localizer, cookieHelper)
        {
        }

        public IActionResult Index()
        {
            List<string> keysToRetrieve = new List<string>
            {
                "Welcome", "Login", "Email", "Password", "Support",
                "ForgotPassword", "RememberMe", "SelectLanguage"
            };

            var viewModel = new DashboardViewModel
            {
                LocalizedValues = GetSubsetLocalizedValues(keysToRetrieve),
                SelectedCulture = GetCurrentCultureName(),
                Page = "Dashboard"
            };

            return View(viewModel);
        }

    }
}
