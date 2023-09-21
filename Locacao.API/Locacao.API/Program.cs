using Locacao.API.Configuration;
using Locacao.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Utils;
using Utils.Connections;
using Locacao.Queries;
using Locacao.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var settings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

Variables.DefaultConnection = settings.DefaultConnection;

//Entity Framework
builder.Services.AddDbContext<LocacaoDbContext>(options =>
{
    options.UseSqlServer(settings.DefaultConnection);
});

//Identity
builder.Services.AddIdentityConfiguration(builder.Configuration);

//MediatR
builder.Services.AddQueries();
builder.Services.AddCommands();

//Dependency Injection
builder.Services.AddDIConfiguration();

//Json Options
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//Automapper
builder.Services.AddAutoMapper(typeof(Program));

//cors
builder.Services.AddCorsConfig();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Development");

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
