using Contatus.Api.Data;
using Contatus.Api.Endpoints;
using Contatus.Api.Handlers;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Pessoas;
using Contatus.Core.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionStr = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(
    x =>
    {
        x.UseSqlServer(connectionStr);
    });

builder.Services.AddEndpointsApiExplorer();

//Front para explora��o da API
//Full Qualified Name
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});

builder.Services.AddTransient<IPessoaHandler, PessoaHandler>();
builder.Services.AddTransient<ITelefoneHandler, TelefoneHandler>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();

app.Run();