using BlockedCountries.Services.Repository.IRepository;
using BlockedCountries.Services.Repository.Repository;
using BlockedCountries.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICountryRepo,CountryRepo>();
builder.Services.AddScoped<ICountryService,CountryService>();

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();

