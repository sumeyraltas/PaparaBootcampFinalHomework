using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Shared;
using PaparaBootcampFinalHomework.Models.Tokens;
using PaparaBootcampFinalHomework.Shared;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program)); 
builder.Services.DIContainers();
builder.Services.AddIdentity<AppAdmin, AppRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<IdentityService>();
//builder.Services.AddScoped<AppRole>();
//builder.Services.AddScoped<AppAdmin>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddAuthentication(options =>
{
    //schema

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    var signatureKey = builder.Configuration.GetSection("TokenOptions")["SignatureKey"]!;
    var issuer = builder.Configuration.GetSection("TokenOptions")["Issuer"]!;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = true,
        ValidIssuer = issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey))
    };
});

var app = builder.Build();

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
