
using Serilog.Events;
using Serilog.Filters;
using Serilog;
using Utils.Middlewares;

#region Logger Configuration

/** Serilog File Setting
 * 
 * ★ File Limit:
 *1. fileSizeLimitBytes: limits file size to 1GB by default，若要移除限制 => fileSizeLimitBytes: null
 *2. retainedFileCountLimit:  the most recent 31 files are retained by default (Day)，若要移除限制=> retainedFileCountLimit: null
 *
 *Rolling policies:
 *1. rollOnFileSizeLimit: To roll when the file reaches fileSizeLimitBytes, 
       specify rollOnFileSizeLimit => rollOnFileSizeLimit: true
 *
 *JSON event formatting:
 *1. exapmle => .WriteTo.File(new CompactJsonFormatter(), "log.txt")
 *
 */

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Debug)
    .Enrich.FromLogContext()
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .WriteTo.Console(outputTemplate: "[{Timestamp: HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}") //Log 寫入Console
    //log統一在一個file
    //.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 31, outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level:u3}]  {Message:lj} <s:{SourceContext}>{NewLine}{Exception}")
    //log分級分開寫入不同file
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
        .WriteTo.File("Logs/LogInformation/LogInformation-.txt", rollingInterval: RollingInterval.Hour, retainedFileCountLimit: 24 * 7, outputTemplate: "[{Timestamp: HH:mm:ss} {Level:u3}]<{ThreadId}> {Message:lj} <s:{SourceContext}>{NewLine}{Exception}"))
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
        .WriteTo.File("Logs/LogError/LogError-.txt", rollingInterval: RollingInterval.Hour, retainedFileCountLimit: 24 * 7, outputTemplate: "[{Timestamp: HH:mm:ss} {Level:u3}]<{ThreadId}> {Message:lj} <s:{SourceContext}>{NewLine}{Exception}"))
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning)
        .WriteTo.File("Logs/LogWarning/LogWarning-.txt", rollingInterval: RollingInterval.Hour, retainedFileCountLimit: 24 * 7, outputTemplate: "[{Timestamp: HH:mm:ss} {Level:u3}]<{ThreadId}> {Message:lj} <s:{SourceContext}>{NewLine}{Exception}"))
   .Filter.ByExcluding(Matching.FromSource("Quartz"))
   .CreateLogger();
#endregion

try
{
    Log.Information("Starting Web Application");

    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();
    builder.Services.AddHttpClient();
    // Add services to the container.
    builder.Services.AddControllersWithViews();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder => builder
               .WithOrigins("http://127.0.0.1:5173") 
               .WithOrigins("http://localhost:5173") 
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler($"/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseCors("CorsPolicy");
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();
    app.UseMiddleware<ExceptionMiddleware>();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
