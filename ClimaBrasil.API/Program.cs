using ClimaBrasil.API.Interfaces;
using ClimaBrasil.API.Mapping;
using ClimaBrasil.API.Rest;
using ClimaBrasil.API.Services;
using ClimaBrasil.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
