global using Microsoft.EntityFrameworkCore;
using crypto_api.Services;
using crypto_api.Services.crypto_api.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var cros = "CrosPolicy";
// Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy(name:cros,
        policy =>
      {
      policy.WithOrigins("http://localhost:4200")
     .AllowAnyMethod()
     .AllowAnyHeader();
        });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CryptoService>();

builder.Services.AddSingleton<GeckoService>();

// Add as hosted service using the instance registered as singleton before
builder.Services.AddHostedService(
    provider => provider.GetRequiredService<GeckoService>()
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
app.UseCors(cros);
app.UseHttpsRedirection();
app.UseAuthorization();


app.MapGet("/background", (
    GeckoService service) =>
{
    return new GeckoServiceState(service.IsEnabled);
});
app.MapMethods("/background", new[] { "PATCH" },
    (
        GeckoServiceState state,
        GeckoService service) =>{ 
            service.IsEnabled = state.IsEnabled;
        }
    );


app.MapControllers();

app.Run();
