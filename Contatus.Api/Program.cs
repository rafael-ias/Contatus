using Contatus.Api.Data;
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

//Front para exploração da API
//Full Qualified Name
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});

builder.Services.AddTransient<IPessoaHandler, PessoaHandler>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

//Versionamento para o caso de atualizações futuras não quebrarem projetos que utilizam dessa API
app.MapPost(
    "/v1/pessoas",
    async (CreatePessoaRequest request, IPessoaHandler handler) => await handler.CreateAsync(request))
    .WithName("Pessoas: Create")
    .Produces<Response<Pessoa>>();

app.MapPut(
    "/v1/pessoas/{id}",
    async (int id, UpdatePessoaRequest request, IPessoaHandler handler) =>
    {
        request.Id = id;
        return await handler.UpdateAsync(request);
    })
    .WithName("Pessoas: Update")
    .Produces<Response<Pessoa?>>();

app.MapDelete(
    "/v1/pessoas/{id}",
    async (int id, IPessoaHandler handler) =>
    {
        var request = new DeletePessoaRequest
        {
            Id = id,
            UserId = "rafael.teste@gmail.com"
        };

        return await handler.DeleteAsync(request);
    })
    .WithName("Pessoas: Delete")
    .Produces<Response<Pessoa?>>();

app.MapGet(
    "/v1/pessoas",
    async (IPessoaHandler handler) =>
    {
        var request = new GetAllPessoasRequest
        {
            UserId = "rafael.teste@gmail.com"
        };

        return await handler.GetAllAsync(request);
    })
    .WithName("Pessoas: GetAll")
    .Produces<PagedResponse<List<Pessoa>?>>();

app.MapGet(
    "/v1/pessoas/{id}",
    async (int id, IPessoaHandler handler) =>
    {
        var request = new GetPessoaByIdRequest
        {
            Id = id,
            UserId = "rafael.teste@gmail.com"
        };

        return await handler.GetByIdAsync(request);
    })
    .WithName("Pessoas: GetById")
    .Produces<Response<Pessoa?>>();

app.Run();