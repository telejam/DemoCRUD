using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Empresa.Application.Interfaces;
using Empresa.Application.Services;
using Empresa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Local Secret
//var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

// Azure Key Vault Secret
var keyVaultURL = new Uri(builder.Configuration["KeyVaultURL"]);
var secretClient = new SecretClient(keyVaultURL, new DefaultAzureCredential());
KeyVaultSecret keyVaultSecret = secretClient.GetSecret("ConnectionString");
var connectionString = keyVaultSecret.Value;

builder.Services.AddDbContext<EmpresaDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IMovimientoService, MovimientoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<IEquipoService, EquipoService>();
builder.Services.AddScoped<IOperarioService, OperarioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
