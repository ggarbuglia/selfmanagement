using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using ProvinciaNET.SelfManagement.Core.Entities.Organization;
using ProvinciaNET.SelfManagement.Core.Entities.Virtualization;
using ProvinciaNET.SelfManagement.Infraestructure.Data;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using ProvinciaNET.SelfManagement.WebApi.Services;
using ProvinciaNET.SelfManagement.WebApi.Services.Organization;
using ProvinciaNET.SelfManagement.WebApi.Services.Virtualization;
using System.Reflection;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add CORS
    var origins = builder.Configuration.GetSection("CORS:AllowedOrigins").Get<string[]>();
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins(origins!);
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.SetPreflightMaxAge(new TimeSpan(1728000));
        });
    });

    // Add NLog to DI
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    // Add ApiKey and OData.
    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ApiKeyAttribute>();
    })
        .AddOData(options =>
        {
            options.AddRouteComponents("odata", ODataHelper.GetModel());
            options.EnableQueryFeatures(maxTopValue: 1000);
        });

    // Add Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.EnableAnnotations();

        options.AddServer(new OpenApiServer()
        {
            Url = builder.Configuration.GetValue<string>("OpenApi:Server")
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

        options.AddSecurityRequirement(new OpenApiSecurityRequirement {
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

    // Add Entity Framework Context
    var cnn = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<SelfManagementContext>(options => { options.UseSqlServer(cnn); });

    // Add Healthchecks
    builder.Services.AddHealthChecks()
        .AddSqlServer(cnn!, "SELECT 1", "sqlserver", HealthStatus.Unhealthy)
        .AddDbContextCheck<SelfManagementContext>("efcontext", HealthStatus.Unhealthy);

    // Add Transient Services
    builder.Services.AddTransient<ICrudServiceBase<AdUserAccountProvision>, AdUserAccountProvisionsService>();
    builder.Services.AddTransient<ICrudServiceBase<AdUserAccount>, AdUserAccountsService>();
    builder.Services.AddTransient<ICrudServiceBase<OrgCostCenter>, OrgCostCentersService>();
    builder.Services.AddTransient<ICrudServiceBase<OrgDirection>, OrgDirectionsService>();
    builder.Services.AddTransient<ICrudServiceBase<OrgLocation>, OrgLocationsService>();
    builder.Services.AddTransient<ICrudServiceBase<OrgMailDatabaseGroup>, OrgMailDatabaseGroupsService>();
    builder.Services.AddTransient<ICrudServiceBase<OrgMembership>, OrgMembershipsService>();
    builder.Services.AddTransient<ICrudServiceBase<OrgSection>, OrgSectionsService>();
    builder.Services.AddTransient<ICrudServiceBase<OrgStructure>, OrgStructuresService>();

    builder.Services.AddTransient<ICrudServiceBase<VirCategoryTag>, VirCategoryTagsService>();
    builder.Services.AddTransient<ICrudServiceBase<VirCluster>, VirClustersService>();
    builder.Services.AddTransient<ICrudServiceBase<VirDataCenter>, VirDataCentersService>();
    builder.Services.AddTransient<ICrudServiceBase<VirDataStore>, VirDataStoresService>();
    builder.Services.AddTransient<ICrudServiceBase<VirNetwork>, VirNetworksService>();
    builder.Services.AddTransient<ICrudServiceBase<VirOperatingSystemType>, VirOperatingSystemTypesService>();
    builder.Services.AddTransient<ICrudServiceBase<VirResource>, VirResourcesService>();
    builder.Services.AddTransient<ICrudServiceBase<VirtualMachine>, VirtualMachinesService>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
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
    app.MapControllers();
    app.MapHealthChecks("/health", new HealthCheckOptions
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