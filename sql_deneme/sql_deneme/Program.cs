using Microsoft.EntityFrameworkCore;
using sql_deneme.Models;
using Microsoft.AspNetCore.Identity;
using sql_deneme.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<SqldenemeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default Connection")));

builder.Services.AddDbContext<sql_denemeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql_denemeContextConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<sql_denemeContext>()
    .AddDefaultTokenProviders();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
