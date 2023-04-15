using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using ProvinciaNET.SelfManagement.Common.Context;
using ProvinciaNET.SelfManagement.WebApi.Helpers;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add NLog to DI
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    // Add OData.
    builder.Services.AddControllers().AddOData(options =>
    {
        options.AddRouteComponents("odata", ODataHelper.GetModel());
        options.EnableQueryFeatures(maxTopValue: 100);
    });

    // Add Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add Entity Framework
    builder.Services.AddDbContext<SelfManagementContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SelfManagement"));
    });

    // Add Transient classes
    builder.Services.AddTransient(typeof(WebApiActionsBaseController<>));

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
    app.UseAuthorization();
    app.UseAuthorization();
    app.MapControllers();

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