using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Settimana6Giorno1.Data;
using Settimana6Giorno1.Models;
using Settimana6Giorno1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(connectionstring)
    );

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{

    options.SignIn.RequireConfirmedAccount =
       builder.Configuration.GetSection("Identity").GetValue<bool>("RequireConfirmedAccount");

    
    options.Password.RequiredLength =
        builder.Configuration.GetSection("Identity").GetValue<int>("RequiredLength");

    options.Password.RequireDigit =
        builder.Configuration.GetSection("Identity").GetValue<bool>("RequireDigit");


    options.Password.RequireLowercase =
        builder.Configuration.GetSection("Identity").GetValue<bool>("RequireLowercase");


    options.Password.RequireNonAlphanumeric =
        builder.Configuration.GetSection("Identity").GetValue<bool>("RequireNonAlphanumeric");


    options.Password.RequireUppercase =
        builder.Configuration.GetSection("Identity").GetValue<bool>("RequireUppercase");
})

    .AddEntityFrameworkStores<StudentDbContext>()

    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(
    options => {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme; 
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme; 
    })
    .AddCookie(options => {
        options.LoginPath = "/Account/Login"; 
        options.AccessDeniedPath = "/Account/Login"; 
        options.Cookie.HttpOnly = true; 
        options.ExpireTimeSpan = TimeSpan.FromHours(1); 
        options.Cookie.Name = "EcommerceLiveEfCore"; 
    });

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<UserManager<ApplicationUser>>(); 
builder.Services.AddScoped<SignInManager<ApplicationUser>>(); 
builder.Services.AddScoped<RoleManager<ApplicationRole>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
