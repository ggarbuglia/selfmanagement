using Microsoft.Extensions.Diagnostics.HealthChecks;
using ProvinciaNET.SelfManagement.WebApp.Models;

namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    public class WebApiHealthCheck : IHealthCheck
    {
        private readonly HttpClient _httpClient;

        public WebApiHealthCheck(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SelfManagementWebApi");
        }

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
