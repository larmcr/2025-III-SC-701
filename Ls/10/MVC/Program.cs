using MVC.Interfaces;
using MVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(provider => (IKeyedServiceProvider)provider);

// builder.Services.AddSingleton<IRandom, RandomTwenty>();

builder.Services.AddKeyedSingleton<IRandom, RandomTen>("Ten");
builder.Services.AddKeyedSingleton<IRandom, RandomTwenty>("Twenty");

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
