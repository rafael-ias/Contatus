using Contatus.Api.Common.Api;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Pessoas;
using Contatus.Core.Responses;

namespace Contatus.Api.Endpoints.Pessoas
{
    public class GetPessoaByIdEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
            => app.MapGet(
                "/v1/pessoas/{id}",
                HandleAsync
            )
            .WithName("Pessoas: GetById")
            .Produces<Response<Pessoa?>>();

        private static async Task<IResult> HandleAsync(IPessoaHandler handler, int id)
        {
            var request = new GetPessoaByIdRequest
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
