using WeatherContracts;
using WeatherServices;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews(); 
builder.Services.AddScoped<IWeatherService, WeatherService>();
var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.UseStaticFiles();   
app.Run();
