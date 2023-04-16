using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using ProvinciaNET.SelfManagement.WebApp.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using NLog.Web;
using NLog;
using Radzen;
using System.Runtime.InteropServices;
using System.DirectoryServices.Protocols;
using System.Net;
using Microsoft.Extensions.DependencyInjection;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var env = builder.Environment;
    var cfg = builder.Configuration;

    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

    // Add NLog to DI
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    // Add Authentication;
    builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate(options =>
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            var srv = cfg["ldap:server"];
            var dom = cfg["ldap:domain"];
            var usr = cfg["ldap:username"];
            var pwd = cfg["ldap:password"];

            if (srv != null)
            {
                logger.Debug(@"LDAP Connection Data: {srv}:389 {dom}\{usr} {pwd}", srv, dom, usr, pwd);

                var srvr = new LdapDirectoryIdentifier(srv, 389);
                var cred = new NetworkCredential(usr, pwd, dom);

                options.EnableLdap(settings =>
                {
                    settings.LdapConnection = new LdapConnection(srvr, cred);
                });
            }
        }
    });

    // Add Authorization
    builder.Services.AddAuthorization(options =>
    {
        options.FallbackPolicy = options.DefaultPolicy;
    });

    // Add Razor and Blazor Server.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    // Add Transient
    builder.Services.AddSingleton<WeatherForecastService>();
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    builder.Services.AddScoped<DialogService>();
    builder.Services.AddScoped<NotificationService>();
    builder.Services.AddScoped<TooltipService>();
    builder.Services.AddScoped<ContextMenuService>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception.");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}