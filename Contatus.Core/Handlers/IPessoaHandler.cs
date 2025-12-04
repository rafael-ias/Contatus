using Contatus.Core.Models;
using Contatus.Core.Requests.Pessoas;
using Contatus.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatus.Core.Handlers
{
    public interface IPessoaHandler
    {
        Task<PagedResponse<List<Pessoa>?>> GetAllAsync(GetAllPessoasRequest request);
        Task<Response<Pessoa?>> GetByIdAsync(GetPessoaByIdRequest request);
        Task<Response<Pessoa?>> CreateAsync(CreatePessoaRequest request);
        Task<Response<Pessoa?>> UpdateAsync(UpdatePessoaRequest request);
        Task<Response<Pessoa?>> DeleteAsync(DeletePessoaRequest request);
    }
}
