using Contatus.Api.Common.Api;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Telefones;
using Contatus.Core.Responses;

namespace Contatus.Api.Endpoints.Telefones
{
    public class UpdateTelefoneEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
            => app.MapPut(
                "/v1/telefones/{id}",
                HandleAsync
            )
            .WithName("Telefones: Update")
            .Produces<Response<Telefone?>>();

        private static async Task<IResult> HandleAsync(ITelefoneHandler handler, UpdateTelefoneRequest request, int id)
        {
            request.Id = id;
            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
        }
    }
}