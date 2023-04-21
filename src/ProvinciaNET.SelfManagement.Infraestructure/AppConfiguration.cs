using Microsoft.Extensions.Configuration;

namespace ProvinciaNET.SelfManagement.Infraestructure
{
    public static class AppConfiguration
    {
        public static string? GetConnectionString(string name)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration.GetConnectionString(name);
        }
    }
}
