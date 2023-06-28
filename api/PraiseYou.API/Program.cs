using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using PraiseYou.Application.Escalas;
using PraiseYou.Application.Identity;
using PraiseYou.Domain;
using PraiseYou.Domain.Escalas.Interface;
using PraiseYou.Domain.Musicas.Interface;
using PraiseYou.Domain.Musicos.Interface;
using PraiseYou.Infrastructure.EntityFramework;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var jwtAudience = env == "Production" ? Environment.GetEnvironmentVariable("Audience") : builder.Configuration["TokenConfiguration:Audience"];
var jwtIssuer = env == "Production" ? Environment.GetEnvironmentVariable("Issuer") : builder.Configuration["TokenConfiguration:Issuer"];
var jwtKey = env == "Production" ? Environment.GetEnvironmentVariable("JwtKey") : builder.Configuration["Jwt:Key"];

if (env == "Production")
{
    var databaseURL = Environment.GetEnvironmentVariable("DATABASE_URL");
    var databaseURI = new Uri(databaseURL);
    var userInfo = databaseURI.UserInfo.Split(':');
    var pgBuilder = new NpgsqlConnectionStringBuilder
    {
        Host = databaseURI.Host,
        Port = databaseURI.Port,
        Username = userInfo[0],
        Password = userInfo[1],
        Database = databaseURI.LocalPath.TrimStart('/'),
        SslMode = SslMode.Require,
        TrustServerCertificate = true,
    };

    builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(pgBuilder.ConnectionString));
}
else
{
    builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}
builder.Services.AddScoped<EscalaFacade>();
builder.Services.AddScoped<EscalaRepository, EFEscalaRepository>();
builder.Services.AddScoped<EscalaMusicaRepository, EFEscalaMusicaRepository>();
builder.Services.AddScoped<EscalaMusicaRepository, EFEscalaMusicaRepository>();

builder.Services.AddScoped<MusicaFacade>();
builder.Services.AddScoped<MusicaRepository, EFMusicaRepository>();

builder.Services.AddScoped<MusicoFacade>();
builder.Services.AddScoped<MusicoRepository, EFMusicoRepository>();

builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<CustomIdentityErrorDescriber>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuer = true,
       ValidateAudience = true,
       ValidateLifetime = true,
       ValidAudience = jwtAudience,
       ValidIssuer = jwtIssuer,
       ValidateIssuerSigningKey = true,
       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
   }
);
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
