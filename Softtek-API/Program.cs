using Application.Features.Empresa.Command.GestionEmpresa;
using Data;
using Data.Base;
using Data.Repositories;
using Data.Repositories_Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy",
            builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithExposedHeaders("X-Pagination")
                    .WithOrigins("http://localhost:4200");

            }));


builder.Services.AddIdentity<Usuario, IdentityRole>()
                                .AddEntityFrameworkStores<SoftteckContext>()
                                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opciones =>
                        opciones.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            //Duracion del token
                            ValidateLifetime = true,
                            //Firma llave privada
                            ValidateIssuerSigningKey = true,
                            //configurar la firma con una llave
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(builder.Configuration["llavejwt"])),
                            ClockSkew = TimeSpan.Zero
                        });

builder.Services.AddDbContext<SoftteckContext>();


builder.Services.AddScoped<IUnitOfWork, DbContextAdapter>();



builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<INotaDetalleRepository, NotaDetalleRepository>();
builder.Services.AddScoped<INotaRepository, NotaRepository>();



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

app.UseCors("CorsPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
