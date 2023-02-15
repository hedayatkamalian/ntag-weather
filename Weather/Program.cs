using Weather.App.Data;
using Weather.App.Options;
using Weather.App.Services.Implements;
using Weather.App.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("cities.json", false);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddHttpClient<WeatherService>();
builder.Services.Configure<OpenWeatherApiOptions>(builder.Configuration.GetSection(nameof(OpenWeatherApiOptions)));
builder.Services.Configure<ApplicationOptions>(builder.Configuration.GetSection(nameof(ApplicationOptions)));
builder.Services.Configure<SampleDataOptions>(builder.Configuration.GetSection(nameof(SampleDataOptions)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
