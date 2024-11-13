using Microsoft.EntityFrameworkCore;
using test_api.Infrastructure.DaoAcess;
using test_api.Infrastructure.Data;
using test_api.Model.Domaine;
using test_api.Model.Interfaces;
using test_api.Model.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BdApp>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddSingleton<ITokenManager, TokenManager>();
builder.Services.AddSingleton<IJWTTokenManager, JWTTokenManager>();

builder.Services.AddScoped<IDAO ,ProductDao>();



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
