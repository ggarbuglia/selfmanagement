using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.Net.Http.Headers;
using NLog;
using NLog.Web;
using ProvinciaNET.SelfManagement.WebApp.Services;
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
        if (baseUri != null) 
        {
            httpClient.BaseAddress = new Uri(baseUri);
            httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        }
    })
        .AddHeaderPropagation(o => o.Headers.Add("Cookie"))
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseDefaultCredentials = true });

    builder.Services.AddHeaderPropagation(o => o.Headers.Add("Cookie"));

    // Add Localization
    builder.Services.AddLocalization();

    // Add HttpContext Accessor
    builder.Services.AddHttpContextAccessor();

    builder.Services.AddScoped<DialogService>();
    builder.Services.AddScoped<NotificationService>();
    builder.Services.AddScoped<TooltipService>();
    builder.Services.AddScoped<ContextMenuService>();
    builder.Services.AddScoped<OrgCostCenterService>();

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
    app.UseHeaderPropagation();
    app.UseRequestLocalization(o => o.AddSupportedCultures("en", "es").AddSupportedUICultures("en", "es").SetDefaultCulture("es"));
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