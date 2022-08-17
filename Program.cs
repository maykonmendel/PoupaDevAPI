using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PoupaDevAPI.Context;
using PoupaDevAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PoupaDevApiConn");

// Add services to the container.

builder.Services.AddDbContext<PoupaDevAPIContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddScoped<IObjetivoFinanceiroRepository, ObjetivoFinanceiroRepository>();
builder.Services.AddScoped<IOperacaoFinanceira, OperacaoFinanceiraRepository>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
