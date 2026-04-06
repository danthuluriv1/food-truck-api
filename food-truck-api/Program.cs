using food_truck_api.Models;
using food_truck_api.Repository;
using food_truck_api.Services;
using System.Reflection;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "development";
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration
    .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
    .AddJsonFile($"appsettings.{env}.json", false)
    .AddEnvironmentVariables()
    .Build();
var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
// Add services to the container.
builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CounterService>();
builder.Services.AddScoped<DatabaseService>();
builder.Services.AddScoped<HttpService>();
builder.Services.AddScoped<CounterRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
var app = builder.Build();

app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
