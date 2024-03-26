using ClimaBrasil.Domain.Abstractions;
//using ClimaBrasil.Infrastructure.Context;
using ClimaBrasil.Infrastructure.Repositories;
using System.Data;
using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;
using ClimaBrasil.Application.BrasilApiRest;
using ClimaBrasil.Application.BrasilApiRest.Interfaces;
using ClimaBrasil.Application.BrasilApiRest.Services;
using ClimaBrasil.Application.BrasilApiRest.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAeroportoService, AeroportoService>();
builder.Services.AddSingleton<ICidadeService, CidadeService>();
builder.Services.AddSingleton<IBrasilApi, BrasilApiRest>();

builder.Services.AddAutoMapper(typeof(AeroportoMapping));
builder.Services.AddAutoMapper(typeof(CidadeMapping));
builder.Services.AddAutoMapper(typeof(ClimaMapping));

builder.Services.AddAutoMapper(typeof(AeroportoEntityDTOMapping));
builder.Services.AddAutoMapper(typeof(CidadeEntityDTOMapping));
builder.Services.AddAutoMapper(typeof(ClimaEntityDTOMapping));

var sqlServerConnection = builder.Configuration
                              .GetConnectionString("DefaultConnection");
                                      // Registrar IDbConnection como uma instância única
builder.Services.AddSingleton<IDbConnection>(provider =>
{
    var connection = new SqlConnection(sqlServerConnection);
    connection.Open();
    return connection;
});

builder.Services.AddScoped<IAeroportosClimaRepository, AeroportosClimaRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICidadesClimaRepository, CidadesClimaRepository>();
builder.Services.AddScoped<IClimaRepository, ClimaRepository>();

var myhandlers = AppDomain.CurrentDomain.Load("ClimaBrasil.Application");
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(myhandlers);
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
