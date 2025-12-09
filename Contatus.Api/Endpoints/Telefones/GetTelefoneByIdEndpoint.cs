using Contatus.Api.Common.Api;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Telefones;
using Contatus.Core.Responses;

namespace Contatus.Api.Endpoints.Telefones
{
    public class GetTelefoneByIdEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
            => app.MapGet(
                "/v1/telefones/{id}",
                HandleAsync
            )
            .WithName("Telefones: GetById")
            .Produces<Response<Telefone?>>();

        private static async Task<IResult> HandleAsync(ITelefoneHandler handler, int id)
        {
            var request = new GetTelefoneByIdRequest
            {
                Id = id
            };

            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
        }
    }
}
