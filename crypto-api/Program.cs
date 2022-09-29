global using crypto_api.Data;
global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var cros = "_CrosPolicy";
// Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy(name:cros,
        policy =>
        {
            policy.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader();
        });
});
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cros);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
