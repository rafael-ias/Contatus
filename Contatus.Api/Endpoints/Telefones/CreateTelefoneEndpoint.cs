using Contatus.Api.Common.Api;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Telefones;
using Contatus.Core.Responses;

namespace Contatus.Api.Endpoints.Telefones
{
    public class CreateTelefoneEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
            => app.MapPost(
                "/v1/telefones/",
                HandleAsync
            )
            .WithName("Telefones: Create")
            .Produces<Response<Telefone?>>();

        private static async Task<IResult> HandleAsync(ITelefoneHandler handler, CreateTelefoneRequest request)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
            ? Results.Created($"/{result.Data?.Id}", result)
            : Results.BadRequest(result);
        }
    }
}
