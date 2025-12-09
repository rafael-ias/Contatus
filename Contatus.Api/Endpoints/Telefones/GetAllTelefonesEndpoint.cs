using Contatus.Api.Common.Api;
using Contatus.Core;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Telefones;
using Contatus.Core.Responses;

namespace Contatus.Api.Endpoints.Telefones
{
    public class GetAllTelefonesEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
            => app.MapGet(
                "/v1/telefones/",
                HandleAsync
            )
            .WithName("Telefones: GetAll")
            .Produces<PagedResponse<List<Telefone>?>>();

        private static async Task<IResult> HandleAsync(ITelefoneHandler handler, int pageNumber = Configuration.PageNumber, int pageSize = Configuration.PageSize)
        {
            var request = new GetAllTelefonesRequest
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
