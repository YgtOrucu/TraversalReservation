using BusinenssLayer.DependencyInjection;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using FluentValidation.AspNetCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 🔥 SERILOG CONFIG
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .WriteTo.File(
        "Logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        fileSizeLimitBytes: 10_000_000, // 10 MB
        rollOnFileSizeLimit: true, //10 mb aşarsa yeni kayıt aç
        retainedFileCountLimit: 7 //7 Gün Log tutar sonra esklileri silp ilerler
    )
    .CreateLogger();

// 🔥 Serilog'u host'a bağla
builder.Host.UseSerilog();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TraversalContext>();

builder.Services
    .AddIdentity<AppUser, AppRole>(config =>
    {
        config.Password.RequiredLength = 5;
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireLowercase = true;
        config.Password.RequireUppercase = true;
        config.Password.RequireDigit = true;
        config.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<TraversalContext>()
    .AddErrorDescriber<TurkishIdentityErrorDescriber>();

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.CustomerValidator();
builder.Services.AddBusinessLayer();


// optional global auth filter
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

// middleware ordering: routing before auth
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=SıgnIn}/{id?}");

app.Run();
