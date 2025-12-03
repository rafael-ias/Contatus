using Contatus.Api.Data;
using Contatus.Core.Models;
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

builder.Services.AddTransient<Handler>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

//Versionamento para o caso de atualizações futuras não quebrarem projetos que utilizam dessa API
app.MapPost(
    "/v1/pessoas",
    (Request request, Handler handler) => Handler.Handle(request))
    .WithName("PessoasV1Create")
    .Produces<Response>();

app.Run();

//Transação
public class Request
{
    public int Id { get; set; }
    public string Nome { get; set; } = String.Empty;
    public string CPF { get; set; } = String.Empty;
    public bool EstaAtivo { get; set; }
    public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
    public string UserId { get; set; } = String.Empty;
}

public class Response
{
    public long Id { get; set; }
    public string Nome { get; set; } = String.Empty;
}

public class Handler
{
    public static Response Handle(Request request)
    {
        return new Response
        {
            Id = 4,
            Nome = request.Nome
        };
    }
}