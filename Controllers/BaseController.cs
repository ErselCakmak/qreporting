using Microsoft.AspNetCore.Mvc;
using qreporting.Helpers;

namespace qreporting.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILocalizationService _localizer;
        protected readonly CookieHelper _cookieHelper;

        public BaseController(ILocalizationService localizer, CookieHelper cookieHelper)
        {
            _localizer = localizer;
            _cookieHelper = cookieHelper;
        }

        public IActionResult ChangeLanguage(string culture)
        {
            _cookieHelper.SetCultureCookie(culture);
            _localizer.GetAllLocalizedValues();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        protected void SetViewBagData(List<string> keysToRetrieve)
        {
            ViewBag.LocalizedValues = _localizer.GetSubsetLocalizedValues(keysToRetrieve);
            ViewBag.SelectedCulture = _cookieHelper.GetCurrentCultureName();
        }

        protected Dictionary<string, string> GetSubsetLocalizedValues(List<string> keysToRetrieve)
        {
            return _localizer.GetSubsetLocalizedValues(keysToRetrieve);
        }

        protected string GetCurrentCultureName()
        {
            return _cookieHelper.GetCurrentCultureName();
        }

        protected string GetThemeModeFromCookie()
        {
            return _cookieHelper.GetThemeModeFromCookie();
        }
    }
}

