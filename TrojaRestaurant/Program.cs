using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrojaRestaurant.DataAccess;
using TrojaRestaurant.DataAccess.Repository;
using TrojaRestaurant.DataAccess.Repository.IRepository;
using TrojaRestaurant;
using Microsoft.AspNetCore.Identity.UI.Services;
using TrojaRestaurant.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext Configuration - Connecting to the SQL Server
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//adding Identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();

//Adding Razor Pages
builder.Services.AddRazorPages();

//Configuring Application Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
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
app.UseAuthentication();

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

//seed data
DbInitializer.seed(app);

app.Run();
