using Microsoft.Extensions.Configuration;

namespace ProvinciaNET.SelfManagement.Infraestructure
{
    /// <summary>
    /// AppConfiguration Class
    /// </summary>
    public static class AppConfiguration
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
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