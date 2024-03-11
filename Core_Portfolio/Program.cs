using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddControllersWithViews();
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

    //app.MapControllerRoute(
    //    name: "default",
    //    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}",
        defaults: new { area = "Writer" }
    );

});
app.UseEndpoints(endpoints =>
{

    _ = endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=Dashboard}/{action=Index}/{id?}"
   );
});
app.Run();
