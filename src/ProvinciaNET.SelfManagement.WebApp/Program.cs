using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using NLog;
using NLog.Web;
using ProvinciaNET.SelfManagement.WebApp.Services;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var env = builder.Environment;
    var cfg = builder.Configuration;

    StaticWebAssetsLoader.UseStaticWebAssets(env, cfg);

    // Add NLog to DI
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    // Register Multiple Services
    builder.Services.RegisterAuthenticationService(cfg, logger);
    builder.Services.RegisterAuthorizationService();
    builder.Services.RegisterCommonServices();
    builder.Services.RegisterHttpClientService(cfg);
    builder.Services.RegisterRadzenBlazorServices();
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