using NLog;
using NLog.Web;
using ProvinciaNET.SelfManagement.WebApi.Services;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var env = builder.Environment;
    var cfg = builder.Configuration;

    // Add NLog to DI
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    builder.Services.RegisterCorsServices(cfg);
    builder.Services.RegisterControllersServices();
    builder.Services.RegisterSwaggerServices(cfg);
    builder.Services.RegisterDbContextServices(cfg);
    builder.Services.RegisterHealthCheckServices(cfg);
    builder.Services.RegisterSelfManagementServices();

    var app = builder.Build();

    app.RegisterUsedApps();
    app.RegisterMappedApps();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception.");
    throw;
}
finally
{
    LogManager.Shutdown();
}