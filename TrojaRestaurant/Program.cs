using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrojaRestaurant.DataAccess;
using TrojaRestaurant.DataAccess.Repository;
using TrojaRestaurant.DataAccess.Repository.IRepository;
using TrojaRestaurant;
using Microsoft.AspNetCore.Identity.UI.Services;
using TrojaRestaurant.Utility;
using Stripe;
using TrojaRestaurant.DataAccess.DbInitializer;
using DocumentFormat.OpenXml.Office.Word;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext Configuration - Connecting to the SQL Server
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//adding Stripe Payment
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

//adding Identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<DataContext>();

//adding UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//adding EmailSender
builder.Services.AddSingleton<IEmailSender, EmailSender>();

//adding DbInitializer
builder.Services.AddScoped<IDbinitializer, DbInitializer>();

//Adding Razor Pages
builder.Services.AddRazorPages();

//Adding Facebook
builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = "487059643435602";
    options.AppSecret = "ade497b58fd4069e6b39f1c5876d4d87";
});

//Configuring Application Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1800);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

app.UseAuthentication();

app.UseAuthorization();
app.UseSession();
SeedDatabase();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbinitializer>();
        dbInitializer.Initialize();
    }
}