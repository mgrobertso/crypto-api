global using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Crypto.Core.Services;
using Crypto.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Mapper = Crypto.Core.Configurations.Mapper;

var builder = WebApplication.CreateBuilder(args);

var cros = "CrosPolicy";
// Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cros,
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

var config = new MapperConfiguration(cfg=>
{
    cfg.AddProfile(new Mapper());
});
var Mapper = config.CreateMapper();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICryptoService, CryptoService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IWatchListService, WatchListService>();
builder.Services.AddSingleton(Mapper);
builder.Services.AddHttpClient();

builder.Services.AddSingleton<GeckoService>();
// Add as hosted service using the instance registered as singleton before
builder.Services.AddHostedService(
    provider => provider.GetRequiredService<GeckoService>()
    );

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = "https://localhost:7037",
    ValidAudience = "https://localhost:7037",
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is a getta dont tell anyone"))
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/Error");
app.UseCors(cros);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();



app.MapGet("/background", (
    GeckoService service) =>
{
    return new GeckoServiceState(service.IsEnabled);
});
app.MapMethods("/background", new[] { "PATCH" },
    (
        GeckoServiceState state,
        GeckoService service) =>
    {
        if (state is null)
        {
            throw new ArgumentNullException(nameof(state));
        }

        service.IsEnabled = state.IsEnabled;
    }
    );


app.MapControllers();


app.Run();
