using Microsoft.Extensions.Configuration;

namespace ProvinciaNET.SelfManagement.Common
{
    public static class AppConfiguration
    {
        public static string? GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .Build();

            return configuration.GetConnectionString("SelfManagement");
        }
    }
}
