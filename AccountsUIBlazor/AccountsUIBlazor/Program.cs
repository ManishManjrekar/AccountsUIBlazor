using AccountsUIBlazor;
using AccountsUIBlazor.Data;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Configure log4net
var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method


var app = builder.Build();
startup.Configure(app, builder.Environment); // calling Configure method
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  //  app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseMvcWithDefaultRoute();
app.MapBlazorHub();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
app.MapFallbackToPage("/_Host");

//app.Run("http://0.0.0.0:80");
app.Run();

