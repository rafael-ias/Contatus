using Contatus.Api.Data;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Pessoas;
using Contatus.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Contatus.Api.Handlers
{
    public class PessoaHandler : IPessoaHandler
    {
        private readonly AppDbContext _context;
        public PessoaHandler(AppDbContext context)
        {
            _context = context;
        }
        // Implementação dos métodos da interface IPessoaHandler
        public PessoaHandler() { }

        async Task<Response<Pessoa?>> IPessoaHandler.CreateAsync(CreatePessoaRequest request)
        {
            try
            {
                var pessoa = new Pessoa
                {
                    Nome = request.Nome,
                    CPF = request.CPF,
                    DataDeNascimento = request.DataDeNascimento,
                    EstaAtivo = request.EstaAtivo,
                    UserId = request.UserId
                };

                await _context.Pessoas.AddAsync(pessoa);
                await _context.SaveChangesAsync();

                return new Response<Pessoa?>(pessoa, 201, "Pessoa cadastrada com sucesso!");
            }
            catch
            {
                return new Response<Pessoa?>(null, 500, "Nao foi possivel cadastrar a Pessoa.");
            }
        }

        async Task<Response<Pessoa?>> IPessoaHandler.DeleteAsync(DeletePessoaRequest request)
        {
            try
            {
                var pessoa = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (pessoa is null)
                {
                    return new Response<Pessoa?>(null, 404, "Pessoa nao encontrada.");
                }
                else
                {
                    _context.Pessoas.Remove(pessoa);
                    await _context.SaveChangesAsync();

                    return new Response<Pessoa?>(pessoa, 200, "Pessoa excluida com sucesso!");
                }
            }
            catch
            {
                return new Response<Pessoa?>(null, 500, "Nao foi possivel excluir a Pessoa.");
            }
        }

        async Task<Response<Pessoa?>> IPessoaHandler.UpdateAsync(UpdatePessoaRequest request)
        {
            try
            {
                var pessoa = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (pessoa is null)
                {
                    return new Response<Pessoa?>(null, 404, "Pessoa nao encontrada.");
                }
                else
                {
                    pessoa.Nome = request.Nome;
                    pessoa.CPF = request.CPF;
                    pessoa.DataDeNascimento = request.DataDeNascimento;
                    pessoa.EstaAtivo = request.EstaAtivo;

                    _context.Pessoas.Update(pessoa);
                    await _context.SaveChangesAsync();

                    return new Response<Pessoa?>(pessoa, 200, "Cadastro de Pessoa atualizado com sucesso!");
                }
            }
            catch
            {
                return new Response<Pessoa?>(null, 500, "Nao foi possivel atualizar o cadastro da Pessoa.");
            }
        }

        async Task<PagedResponse<List<Pessoa>?>> IPessoaHandler.GetAllAsync(GetAllPessoasRequest request)
        {
            try
            {
                var query = _context.Pessoas
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .Include(x => x.Telefones)
                    .OrderBy(x => x.Nome);

                var pessoas = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Pessoa>?>(pessoas, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Pessoa>?>(null, 500, "Nao foi possivel recuperar a lista de Pessoas.");
            }
        }

        async Task<Response<Pessoa?>> IPessoaHandler.GetByIdAsync(GetPessoaByIdRequest request)
        {
            try
            {
                var pessoa = await _context.Pessoas
                    .AsNoTracking()
                    .Include(x => x.Telefones)
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return pessoa is null
                    ? new Response<Pessoa?>(null, 404, "Pessoa nao encontrada.")
                    : new Response<Pessoa?>(pessoa);
            }
            catch
            {
                return new Response<Pessoa?>(null, 500, "Nao foi possivel recuperar o cadastro da Pessoa.");
            }
        }
    }
}
