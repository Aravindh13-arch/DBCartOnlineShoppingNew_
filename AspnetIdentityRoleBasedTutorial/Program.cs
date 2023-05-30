using AspnetIdentityRoleBasedTutorial.Data;
using AspnetIdentityRoleBasedTutorial.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.BAL;
using OnlineShoppingProject.DAL;
using OnlineShoppingProject.Models;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Add Scope
builder.Services.AddScoped<OnlineShopDbContext>();
builder.Services.AddScoped<ProductImplemenationBAL, ProductImplemenationBAL>();
builder.Services.AddScoped<ProductImplemenationDAL, ProductImplemenationDAL>();
builder.Services.AddScoped<AddressImplementation, AddressImplementation>();
builder.Services.AddScoped<AddressImplementationDAL, AddressImplementationDAL>();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<OnlineShopDbContext>();
builder.Services.AddScoped<CartImplememntationBAL, CartImplememntationBAL>();
builder.Services.AddScoped<CartImplememntationDAL, CartImplememntationDAL>();
builder.Services.AddScoped<CommonImplementationDAL, CommonImplementationDAL>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}
app.Run();
