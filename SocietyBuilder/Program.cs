using SocietyBuilder.Services.RealEconomy;
using SocietyBuilder.Services.PhysicSpace;
using SocietyBuilder.Services.PopulationGenerator;
using SocietyBuilder.Services.Tenancy;
using SocietyBuilder.Services.GameCore;
using SocietyBuilder.Services.UniversalServices;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllersWithViews();
services.AddRouting(config => config.LowercaseQueryStrings = true);
string universalSettings = "UniversalSettings";
services.Configure<UniversalSettings>(builder.Configuration.GetSection(universalSettings));

services.AddTransient<IExcelManager, ExcelManager>();
services.AddTransient<IPhysicConstructor, PhysicSpaceConstructor>();
services.AddTransient<IPopulationGenerator, PopulationGenerator>();
services.AddTransient<ITenancyService, TenancyService>();
services.AddTransient<IEconomicActivityService, EconomicActivityService>();
services.AddTransient<IGameCore, GameCore>();

// inject Service Provider
UniversalServiceProvider.ServiceProvider = services.BuildServiceProvider();

services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
