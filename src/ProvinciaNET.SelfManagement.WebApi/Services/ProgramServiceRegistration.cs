using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using ProvinciaNET.SelfManagement.WebApi.Services.Organization;
using ProvinciaNET.SelfManagement.WebApi.Services.Virtualization;
using System.Reflection;

namespace ProvinciaNET.SelfManagement.WebApi.Services
{
    /// <summary>
    ///
    /// </summary>
    public static class ProgramServiceRegistration
    {
        /// <summary>
        /// Registers the CORS services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterCorsServices(this IServiceCollection services, IConfiguration config)
        {
            var origins = config.GetSection("CORS:AllowedOrigins").Get<string[]>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(origins!);
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.SetPreflightMaxAge(new TimeSpan(1728000));
                });
            });

            return services;
        }

        /// <summary>
        /// Registers the controllers services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterControllersServices(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ApiKeyAttribute>();
            })
                .AddOData(options =>
                {
                    options.AddRouteComponents("odata", ODataHelper.GetModel());
                    options.EnableQueryFeatures(maxTopValue: 1000);
                });

            return services;
        }

        /// <summary>
        /// Registers the Swagger services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterSwaggerServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();

                options.AddServer(new OpenApiServer()
                {
                    Url = config.GetValue<string>("OpenApi:Server")
                });

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Provincia NET SelfManagement API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Germán Pablo Garbuglia",
                        Email = "german.garbuglia@gmail.com",
                        Url = new Uri("https://twitter.com/ggarbuglia")
                    }
                });

                options.AddSecurityDefinition(name: "ApiKey", securityScheme: new OpenApiSecurityScheme
                {
                    Name = "x-api-key",
                    Description = "Enter the API Authorizacion Key",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Scheme = "ApiKeyScheme"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference {
                                Id = "ApiKey",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });

                options.TagActionsBy(desc =>
                {
                    if (desc.GroupName != null) return new[] { desc.GroupName };
                    if (desc.ActionDescriptor is ControllerActionDescriptor descriptor) return new[] { descriptor.ControllerName };
                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });

                options.DocInclusionPredicate((name, desc) => true);

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                var modelAssembly = typeof(SelfManagementContext).Assembly;
                var modelFilename = $"{modelAssembly.GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, modelFilename));

                options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"]}");
            });

            return services;
        }

        /// <summary>
        /// Registers the database context services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterDbContextServices(this IServiceCollection services, IConfiguration config)
        {
            var cnn = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<SelfManagementContext>(options => { options.UseSqlServer(cnn); });

            return services;
        }

        /// <summary>
        /// Registers the health check services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterHealthCheckServices(this IServiceCollection services, IConfiguration config)
        {
            var cnn = config.GetConnectionString("DefaultConnection");
            services.AddHealthChecks()
                .AddSqlServer(cnn!, "SELECT 1", "sqlserver", HealthStatus.Unhealthy)
                .AddDbContextCheck<SelfManagementContext>("efcontext", HealthStatus.Unhealthy);

            return services;
        }

        /// <summary>
        /// Registers the SelfManagement services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterSelfManagementServices(this IServiceCollection services)
        {
            services.AddScoped<ICrudServiceBase<AdUserAccountProvision>, AdUserAccountProvisionsService>();
            services.AddScoped<ICrudServiceBase<AdUserAccount>, AdUserAccountsService>();
            services.AddScoped<ICrudServiceBase<OrgCostCenter>, OrgCostCentersService>();
            services.AddScoped<ICrudServiceBase<OrgDirection>, OrgDirectionsService>();
            services.AddScoped<ICrudServiceBase<OrgLocation>, OrgLocationsService>();
            services.AddScoped<ICrudServiceBase<OrgMailDatabaseGroup>, OrgMailDatabaseGroupsService>();
            services.AddScoped<ICrudServiceBase<OrgMembership>, OrgMembershipsService>();
            services.AddScoped<ICrudServiceBase<OrgSection>, OrgSectionsService>();
            services.AddScoped<ICrudServiceBase<OrgStructure>, OrgStructuresService>();

            services.AddScoped<ICrudServiceBase<VirCategoryTag>, VirCategoryTagsService>();
            services.AddScoped<ICrudServiceBase<VirCluster>, VirClustersService>();
            services.AddScoped<ICrudServiceBase<VirDataCenter>, VirDataCentersService>();
            services.AddScoped<ICrudServiceBase<VirDataStore>, VirDataStoresService>();
            services.AddScoped<ICrudServiceBase<VirNetwork>, VirNetworksService>();
            services.AddScoped<ICrudServiceBase<VirOperatingSystemType>, VirOperatingSystemTypesService>();
            services.AddScoped<ICrudServiceBase<VirResource>, VirResourcesService>();
            services.AddScoped<ICrudServiceBase<VirtualMachine>, VirtualMachinesService>();

            return services;
        }

        /// <summary>
        /// Registers the used apps.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public static WebApplication RegisterUsedApps(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseODataRouteDebug();
                app.UseDeveloperExceptionPage();
            };

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
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
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            return app;
        }
    }
}