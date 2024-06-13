using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsSite.Data;
using NewsSite.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddMemoryCache();
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("OnlyForAdminPolicy", policy => policy.RequireClaim("Status", "admin"));
    opt.AddPolicy("ForSuperUserPolicy", policy => policy.RequireClaim("Status", "superUser"));
    opt.AddPolicy("ForUserPolicy", policy => policy.RequireClaim("Status", "user"));
    opt.AddPolicy("GeneralPolicy", policy => policy.RequireClaim("Status", new string[] { "admin", "superUser", "user", "moderator" }));
});
builder.Services.AddRazorPages(opt =>
{
    opt.Conventions.AuthorizeAreaPage("/Identity", "/Pages/EditArticle", "OnlyForAdminPolicy");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
