using Microsoft.EntityFrameworkCore;
using Models.Shared;
using PaparaBootcampFinalHomework.Models.Tokens;
using PaparaBootcampFinalHomework.Shared;

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
builder.Services.AddScoped<TokenService>();

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
