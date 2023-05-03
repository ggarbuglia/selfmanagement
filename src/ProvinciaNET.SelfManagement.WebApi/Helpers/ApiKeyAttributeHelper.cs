using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ProvinciaNET.SelfManagement.WebApi.Helpers
{
    /// <summary>
    /// ApiKeyAttribute Class
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter" />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ApiKeyAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// Called early in the filter pipeline to confirm request is authorized.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext" />.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var configuration   = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var internalApiKey  = $"{configuration.GetValue<string>("OpenApi:ApiKey")}{DateTime.Now:yyyyMMdd}";
            var submittedApiKey = context.HttpContext.Request.Headers["x-api-key"];
            
            if (!IsApiKeyValid(internalApiKey, submittedApiKey))
                context.Result = new UnauthorizedResult();
        }

        /// <summary>
        /// Determines whether [is API key valid] [the specified internal API key].
        /// </summary>
        /// <param name="internalApiKey">The internal API key.</param>
        /// <param name="submittedApiKey">The submitted API key.</param>
        /// <returns>
        ///   <c>true</c> if [is API key valid] [the specified internal API key]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsApiKeyValid(string? internalApiKey, string? submittedApiKey)
        {
            if (string.IsNullOrEmpty(submittedApiKey) || string.IsNullOrEmpty(internalApiKey)) return false;

            var internalApiKeySpan = MemoryMarshal.Cast<char, byte>(internalApiKey.AsSpan());
            var submittedApiKeySpan = MemoryMarshal.Cast<char, byte>(submittedApiKey.AsSpan());

            return CryptographicOperations.FixedTimeEquals(internalApiKeySpan, submittedApiKeySpan);
        }
    }
}
