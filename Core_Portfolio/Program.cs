using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});



builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.AccessDeniedPath= "/ErrorPage/Index/";
    options.LoginPath = "/Home/Index/";
});


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

    
    app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseAuthentication( );
    
    app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "MyAreaWriter",
    areaName: "Writer",
    pattern: "Writer/{controller=Login}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseEndpoints(endpoints =>
{

    _ = endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}",
      defaults: new { area = "Writer" });

    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Dashboard}/{action=Index}/{id?}");
});

app.Run();
