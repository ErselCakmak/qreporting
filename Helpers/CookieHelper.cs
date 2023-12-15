using Microsoft.AspNetCore.Localization;

namespace qreporting.Helpers
{
    public class CookieHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GetThemeModeFromCookie()
        {
            return _httpContextAccessor.HttpContext?.Request?.Cookies["themeMode"] ?? "light";
        }

        public void SetCultureCookie(string culture)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            httpContext?.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.MaxValue
                    });
        }

        public string GetCurrentCultureName()
        {
            return _httpContextAccessor.HttpContext?.Request?.HttpContext?.Features?.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "tr-TR";
        }
    }

}

