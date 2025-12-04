using Contatus.Api.Common.Api;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Pessoas;
using Contatus.Core.Responses;

namespace Contatus.Api.Endpoints.Pessoas
{
    public class CreatePessoaEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
            => app.MapPost(
                "/",
                HandleAsync
            )
            .WithName("Pessoas: Create")
            .Produces<Response<Pessoa?>>();

        private static async Task<IResult> HandleAsync(IPessoaHandler handler, CreatePessoaRequest request)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
            ? Results.Created($"/{result.Data?.Id}", result.Data)
            : Results.BadRequest(result.Data);
        }
    }
}
