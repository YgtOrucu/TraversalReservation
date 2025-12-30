using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using BusinenssLayer.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


builder.Services.AddBusinessLayer();

// optional global auth filter
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

// middleware ordering: routing before auth
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
