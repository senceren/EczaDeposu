using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ApplicationCore.Interfaces;
using Web.Interfaces;
using Web.Services;
using ApplicationCore.Services;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EczaDeposuContext>(ob => ob.UseSqlServer(builder.Configuration.GetConnectionString("EczaDeposuContext")));

builder.Services.AddDbContext<EczaDeposuIdentityContext>(ob => ob.UseSqlServer(builder.Configuration.GetConnectionString("EczaDeposuIdentityContext")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EczaDeposuIdentityContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
builder.Services.AddScoped<IHomeViewModelService, HomeViewModelService>();
builder.Services.AddScoped<IBasketViewModelService, BasketViewModelService>();
builder.Services.AddScoped<IOrderViewModelService, OrderViewModelService>();
builder.Services.AddScoped<IMedicineViewModelService, MedicineViewModelService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddHttpContextAccessor();

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
      name: "areas",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var watchHubContext = scope.ServiceProvider.GetRequiredService<EczaDeposuContext>();
    await EczaDeposuContextSeed.SeedAsync(watchHubContext);

    var appIdentityContext = scope.ServiceProvider.GetRequiredService<EczaDeposuIdentityContext>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    await EczaDeposuIdentityContextSeed.SeedAsync(appIdentityContext, roleManager, userManager);
}

app.Run();
