using Contatus.Api.Common.Api;
using Contatus.Core;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Pessoas;
using Contatus.Core.Responses;

namespace Contatus.Api.Endpoints.Pessoas
{
    public class GetAllPessoasEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
            => app.MapGet(
                "/v1/pessoas/",
                HandleAsync
            )
            .WithName("Pessoas: GetAll")
            .Produces<PagedResponse<List<Pessoa>?>>();

        private static async Task<IResult> HandleAsync(IPessoaHandler handler, int pageNumber = Configuration.PageNumber, int pageSize = Configuration.PageSize)
        {
            var request = new GetAllPessoasRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetAllAsync(request);

            return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result);
        }
    }
}
