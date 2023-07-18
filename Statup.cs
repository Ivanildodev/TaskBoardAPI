using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TaskBoardAPI.Data;
using TaskBoardAPI.Data.Repositories;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.Profile;
using TaskBoardAPI.Services;
using TaskBoardAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fluxo", Version = "v1" });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

var mapper = AutoMapperConfig.Configure();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IArmazenadorDeColaborador, ArmazenadorDeColaborador>();
builder.Services.AddScoped<IArmazenadorDeCargo, ArmazenadorDeCargo>();
builder.Services.AddScoped<IArmazenadorDeCard, ArmazenadorDeCard>();
builder.Services.AddScoped<IArmazenadorDeTarefa, ArmazenadorDeTarefa>();
builder.Services.AddScoped<IExcluidorDeColaborador, ExcluidorDeColaborador>();
builder.Services.AddScoped<IExcluidorDeCargo, ExcluidorDeCargo>();
builder.Services.AddScoped<IExcluidorDeCard, ExcluidorDeCard>();
builder.Services.AddScoped<IExcluidorDeTarefa, ExcluidorDeTarefa>();
builder.Services.AddScoped<IColaboradorRepositorio, ColaboradorRepositorio>();
builder.Services.AddScoped<ICargoRepositorio, CargoRepositorio>();
builder.Services.AddScoped<ICardRepositorio, CardRepositorio>();
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
