global using crypto_api.Data;
global using Microsoft.EntityFrameworkCore;
using crypto_api.Services;
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
builder.Services.AddScoped<ICryptoService, CryptoService>();

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

app.MapControllers();

app.Run();
