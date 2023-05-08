using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Net.Http.Headers;
using NLog;
using ProvinciaNET.SelfManagement.WebApp.Services.Organization;
using Radzen;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Runtime.InteropServices;

namespace ProvinciaNET.SelfManagement.WebApp.Services
{
    /// <summary>
    /// Program Service Registration Class
    /// </summary>
    public static class ProgramServiceRegistration
    {
        /// <summary>
        /// Registers the common services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterCommonServices(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();
            services.AddLocalization();
            services.AddHealthChecks().AddCheck<WebApiHealthCheck>("webapi", HealthStatus.Unhealthy);

            return services;
        }

        /// <summary>
        /// Registers the authentication service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The CFG.</param>
        /// <param name="logger">The logger.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterAuthenticationService(this IServiceCollection services, IConfiguration config, Logger logger)
        {
            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate(o =>
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    var srv = config["ldap:server"];
                    var dom = config["ldap:domain"];
                    var usr = config["ldap:username"];
                    var pwd = config["ldap:password"];

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

            return services;
        }

        /// <summary>
        /// Registers the authorization service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterAuthorizationService(this IServiceCollection services)
        {
            services.AddAuthorization(o =>
            {
                o.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });

            return services;
        }

        /// <summary>
        /// Registers the HTTP client service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterHttpClientService(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient("SelfManagementWebApi", httpClient =>
            {
                var baseUri = config["Services:SelfManagementWebApiBaseUri"];
                var baseKey = config["Services:SelfManagementWebApiKey"];
                if (!string.IsNullOrEmpty(baseUri) && !string.IsNullOrEmpty(baseKey))
                {
                    httpClient.BaseAddress = new Uri(baseUri);
                    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                    httpClient.DefaultRequestHeaders.Add("x-api-key", $"{baseKey}{DateTime.Now:yyyyMMdd}");
                }
            })
                .AddHeaderPropagation(o => o.Headers.Add("Cookie"))
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseDefaultCredentials = true });

            return services;
        }

        /// <summary>
        /// Registers the Radzen Blazor services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterRadzenBlazorServices(this IServiceCollection services) 
        {
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();

            return services;
        }

        /// <summary>
        /// Registers the SelfManagement services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterSelfManagementServices(this IServiceCollection services) 
        {
            services.AddScoped<OrgCostCenterService>();
            services.AddScoped<OrgDirectionService>();
            services.AddScoped<OrgLocationService>();
            services.AddScoped<OrgMailDatabaseGroupService>();
            services.AddScoped<OrgMembershipService>();
            services.AddScoped<OrgSectionService>();
            services.AddScoped<OrgStructureService>();

            return services;
        }

        /// <summary>
        /// Registers the used apps.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public static WebApplication RegisterUsedApps(this WebApplication app) 
        {
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

            return app;
        }

        /// <summary>
        /// Registers the mapped apps.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public static WebApplication RegisterMappedApps(this WebApplication app) 
        {
            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.MapHealthChecks("/health",
                new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

            return app;
        }
    }
}
