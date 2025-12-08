using Contatus.Api.Common.Api;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Pessoas;
using Contatus.Core.Responses;

namespace Contatus.Api.Endpoints.Pessoas
{
    public class UpdatePessoaEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
            => app.MapPut(
                "/v1/pessoas/{id}",
                HandleAsync
            )
            .WithName("Pessoas: Update")
            .Produces<Response<Pessoa?>>();

        private static async Task<IResult> HandleAsync(IPessoaHandler handler, UpdatePessoaRequest request, int id)
        {
            request.Id = id;
            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
        }
    }
}