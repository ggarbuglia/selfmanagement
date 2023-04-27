using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ProvinciaNET.SelfManagement.WebApp.Controllers
{
    [Route("culture/[action]")]
    public partial class CultureController : Controller
    {
        [ActionName("setculture")]
        public IActionResult SetCulture(string culture, string redirectUri)
        {
            if (culture != null)
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
            }

            return LocalRedirect(redirectUri);
        }
    }
}