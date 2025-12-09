using Contatus.Api.Common.Api;
using Contatus.Api.Endpoints.Pessoas;
using Contatus.Api.Endpoints.Telefones;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Pessoas;
using Contatus.Core.Responses;

namespace Contatus.Api.Endpoints
{
    public static class Endpoints
    {
        public static void MapEndpoints (this WebApplication app)
        {
            new CreatePessoaEndpoint().Map(app);
            new UpdatePessoaEndpoint().Map(app);
            new DeletePessoaEndpoint().Map(app);
            new GetAllPessoasEndpoint().Map(app);
            new GetPessoaByIdEndpoint().Map(app);

            new CreateTelefoneEndpoint().Map(app);
            new UpdateTelefoneEndpoint().Map(app);
            new DeleteTelefoneEndpoint().Map(app);
            new GetAllTelefonesEndpoint().Map(app);
            new GetTelefoneByIdEndpoint().Map(app);
        }
    }
}
