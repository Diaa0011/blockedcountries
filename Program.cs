using BlockedCountries.Service.Repository.IRepository;
using BlockedCountries.Service.Repository.Repository;
using BlockedCountries.Service.Service;
using BlockedCountries.Service.Service.IService;
using BlockedCountries.Service.Service.Service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Serilog configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();
builder.Services.AddHostedService<unBlockTempService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//for ip part and parsing
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ICountryRepo,CountryRepo>();
builder.Services.AddScoped<IIpRepo,IpRepo>();
builder.Services.AddSingleton<ILogRepo,LogRepo>();
builder.Services.AddScoped<ICountryService,CountryService>();
builder.Services.AddScoped<IIpService,IpService>();
builder.Services.AddScoped<ILogService,LogService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>{
         c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
         c.RoutePrefix = string.Empty; // Set as home page
    });
}

app.Lifetime.ApplicationStopping.Register(Log.CloseAndFlush);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();

