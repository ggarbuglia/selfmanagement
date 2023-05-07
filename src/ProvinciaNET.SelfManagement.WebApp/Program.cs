using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Net.Http.Headers;
using NLog;
using NLog.Web;
using ProvinciaNET.SelfManagement.WebApp.Services;
using ProvinciaNET.SelfManagement.WebApp.Services.Organization;
using Radzen;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Runtime.InteropServices;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
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

    // Add Authentication;
    builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate(o =>
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

                o.EnableLdap(settings =>
                {
                    settings.LdapConnection = new LdapConnection(srvr, cred);
                });
            }
        }
    });

    // Add Authorization
    builder.Services.AddAuthorization(o =>
    {
        o.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    });

    // Add Razor and Blazor Server.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    // Add HttpClientFactory Named Client
    builder.Services.AddHttpClient("SelfManagementWebApi", httpClient =>
    {
        var baseUri = cfg["Services:SelfManagementWebApiBaseUri"];
        var baseKey = cfg["Services:SelfManagementWebApiKey"];
        if (!string.IsNullOrEmpty(baseUri) && !string.IsNullOrEmpty(baseKey))
        {
            httpClient.BaseAddress = new Uri(baseUri);
            httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            httpClient.DefaultRequestHeaders.Add("x-api-key", $"{baseKey}{DateTime.Now:yyyyMMdd}");
        }
    })
        .AddHeaderPropagation(o => o.Headers.Add("Cookie"))
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseDefaultCredentials = true });

    builder.Services.AddHeaderPropagation(o => o.Headers.Add("Cookie"));

    // Add Localization
    builder.Services.AddLocalization();

    // Add Healthchecks
    builder.Services.AddHealthChecks()
        .AddCheck<WebApiHealthCheck>("webapi", HealthStatus.Unhealthy);

    // Add HttpContext Accessor
    builder.Services.AddHttpContextAccessor();

    // Add Radzen Scoped Services
    builder.Services.AddScoped<DialogService>();
    builder.Services.AddScoped<NotificationService>();
    builder.Services.AddScoped<TooltipService>();
    builder.Services.AddScoped<ContextMenuService>();

    // Add SelfManagement Scoped Services
    builder.Services.AddScoped<OrgCostCenterService>();
    builder.Services.AddScoped<OrgDirectionService>();
    builder.Services.AddScoped<OrgLocationService>();
    builder.Services.AddScoped<OrgMailDatabaseGroupService>();
    builder.Services.AddScoped<OrgMembershipService>();
    builder.Services.AddScoped<OrgSectionService>();
    builder.Services.AddScoped<OrgStructureService>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseHeaderPropagation();
    app.UseRequestLocalization(options =>
    {
        options.AddSupportedCultures("en", "es");
        options.AddSupportedUICultures("en", "es");
        options.SetDefaultCulture("es");
    });
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");
    app.MapHealthChecks("/health",
        new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

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