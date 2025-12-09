using Contatus.Core.Models;
using Contatus.Core.Requests.Telefones;
using Contatus.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatus.Core.Handlers
{
    public interface ITelefoneHandler
    {
        Task<PagedResponse<List<Telefone>?>> GetAllAsync(GetAllTelefonesRequest request);
        Task<Response<Telefone?>> GetByIdAsync(GetTelefoneByIdRequest request);
        Task<Response<Telefone?>> CreateAsync(CreateTelefoneRequest request);
        Task<Response<Telefone?>> UpdateAsync(UpdateTelefoneRequest request);
        Task<Response<Telefone?>> DeleteAsync(DeleteTelefoneRequest request);
    }
}
