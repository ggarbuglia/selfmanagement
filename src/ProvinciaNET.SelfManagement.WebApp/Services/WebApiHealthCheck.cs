using Microsoft.Extensions.Diagnostics.HealthChecks;
using ProvinciaNET.SelfManagement.WebApp.Models;

namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    /// <summary>
    /// WebApiHealthCheck Class
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck" />
    public class WebApiHealthCheck : IHealthCheck
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiHealthCheck"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        public WebApiHealthCheck(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
        }

        /// <summary>
        /// Runs the health check, returning the status of the component being checked.
        /// </summary>
        /// <param name="context">A context object associated with the current execution.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> that can be used to cancel the health check.</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1" /> that completes when the health check has finished, yielding the status of the component being checked.
        /// </returns>
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/health");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<HealthCheckUIResult>();

                var healthCheckResult = HealthCheckResult.Healthy();

                if (result != null) 
                {
                    switch (result.Status)
                    {
                        case "degraded":
                            healthCheckResult = HealthCheckResult.Degraded();
                            break;
                        case "unhealthy":
                            healthCheckResult = HealthCheckResult.Unhealthy();
                            break;
                    }
                }

                return await Task.FromResult(healthCheckResult);
            }
            catch (Exception)
            {
                return await Task.FromResult(HealthCheckResult.Unhealthy());
            }
        }
    }
}
