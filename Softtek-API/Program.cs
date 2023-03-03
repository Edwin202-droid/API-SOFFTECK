using Application.Features.Empresa.Command.GestionEmpresa;
using Data;
using Data.Base;
using Data.Repositories;
using Data.Repositories_Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SoftteckContext>();


builder.Services.AddScoped<IUnitOfWork, DbContextAdapter>();



builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();


builder.Services.AddMediatR(typeof(GestionEmpresaCommand).Assembly);
builder.Services.AddAutoMapper(typeof(GestionEmpresaCommand).Assembly);

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
