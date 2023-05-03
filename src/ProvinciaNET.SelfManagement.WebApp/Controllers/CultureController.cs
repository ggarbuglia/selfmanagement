using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ProvinciaNET.SelfManagement.WebApp.Controllers
{
    /// <summary>
    /// Culture Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("culture/[action]")]
    public partial class CultureController : Controller
    {
        /// <summary>
        /// Sets the culture.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <returns></returns>
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