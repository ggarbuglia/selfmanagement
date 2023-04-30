﻿using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NLog;
using NLog.Web;
using ProvinciaNET.SelfManagement.Infraestructure.Data;
using ProvinciaNET.SelfManagement.WebApi.Helpers;
using ProvinciaNET.SelfManagement.WebApi.Interfaces;
using ProvinciaNET.SelfManagement.WebApi.Services;

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

    // Add OData.
    builder.Services.AddControllers()
        .AddOData(options =>
        {
            options.AddRouteComponents("odata", ODataHelper.GetModel());
            options.EnableQueryFeatures(maxTopValue: 1000);
        });

    // Add Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add Entity Framework Context
    var cnn = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<SelfManagementContext>(options =>
    {
        options.UseSqlServer(cnn);
    });

    // Add Healthchecks
    builder.Services.AddHealthChecks()
        .AddSqlServer(cnn!, "SELECT 1", "sqlserver", HealthStatus.Unhealthy)
        .AddDbContextCheck<SelfManagementContext>("efcontext", HealthStatus.Unhealthy);

    // Add Scoped Services
    builder.Services.AddScoped<IAdUserAccountProvisionsService, AdUserAccountProvisionsService>();
    builder.Services.AddScoped<IAdUserAccountsService, AdUserAccountsService>();
    builder.Services.AddScoped<IOrgCostCentersService, OrgCostCentersService>();
    builder.Services.AddScoped<IOrgDirectionsService, OrgDirectionsService>();
    builder.Services.AddScoped<IOrgLocationsService, OrgLocationsService>();
    builder.Services.AddScoped<IOrgMailDatabaseGroupsService, OrgMailDatabaseGroupsService>();
    builder.Services.AddScoped<IOrgMembershipsService, OrgMembershipsService>();
    builder.Services.AddScoped<IOrgSectionsService, OrgSectionsService>();
    builder.Services.AddScoped<IOrgStructuresService, OrgStructuresService>();

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