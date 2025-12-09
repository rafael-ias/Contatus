using Contatus.Api.Data;
using Contatus.Core.Handlers;
using Contatus.Core.Models;
using Contatus.Core.Requests.Telefones;
using Contatus.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Contatus.Api.Handlers
{
    public class TelefoneHandler : ITelefoneHandler
    {
        private readonly AppDbContext _context;
        public TelefoneHandler(AppDbContext context)
        {
            _context = context;
        }
        // Implementação dos métodos da interface ITelefoneHandler
        public TelefoneHandler() { }

        async Task<Response<Telefone?>> ITelefoneHandler.CreateAsync(CreateTelefoneRequest request)
        {
            try
            {
                var telefone = new Telefone
                {
                    Tipo = request.Tipo,
                    Numero = request.Numero,
                    PessoaId = request.PessoaId,
                    UserId = request.UserId
                };

                await _context.Telefones.AddAsync(telefone);
                await _context.SaveChangesAsync();

                return new Response<Telefone?>(telefone, 201, "Telefone cadastrado com sucesso!");
            }
            catch
            {
                return new Response<Telefone?>(null, 500, "Nao foi possivel cadastrar o Telefone.");
            }
        }

        async Task<Response<Telefone?>> ITelefoneHandler.UpdateAsync(UpdateTelefoneRequest request)
        {
            try
            {
                var telefone = await _context.Telefones.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (telefone is null)
                {
                    return new Response<Telefone?>(null, 404, "Telefone nao encontrado.");
                }
                else
                {
                    telefone.Tipo = request.Tipo;
                    telefone.Numero = request.Numero;

                    _context.Telefones.Update(telefone);
                    await _context.SaveChangesAsync();

                    return new Response<Telefone?>(telefone, 200, "Cadastro de Telefone atualizado com sucesso!");
                }
            }
            catch
            {
                return new Response<Telefone?>(null, 500, "Nao foi possivel atualizar o cadastro do Telefone.");
            }
        }

        async Task<Response<Telefone?>> ITelefoneHandler.DeleteAsync(DeleteTelefoneRequest request)
        {
            try
            {
                var telefone = await _context.Telefones.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (telefone is null)
                {
                    return new Response<Telefone?>(null, 404, "Telefone nao encontrado.");
                }
                else
                {
                    _context.Telefones.Remove(telefone);
                    await _context.SaveChangesAsync();

                    return new Response<Telefone?>(telefone, 200, "Telefone excluido com sucesso!");
                }
            }
            catch
            {
                return new Response<Telefone?>(null, 500, "Nao foi possivel excluir o Telefone.");
            }
        }

        async Task<PagedResponse<List<Telefone>?>> ITelefoneHandler.GetAllAsync(GetAllTelefonesRequest request)
        {
            try
            {
                var query = _context.Telefones
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderBy(x => x.Pessoa);

                var telefones = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Telefone>?>(telefones, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Telefone>?>(null, 500, "Nao foi possivel recuperar a lista de Telefones.");
            }
        }

        async Task<Response<Telefone?>> ITelefoneHandler.GetByIdAsync(GetTelefoneByIdRequest request)
        {
            try
            {
                var telefone = await _context.Telefones.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (telefone is null)
                {
                    
                    return new Response<Telefone?>(null, 404, "Telefone nao encontrado.");
                }
                return new Response<Telefone?>(telefone);
            }
            catch
            {
                return new Response<Telefone?>(null, 500, "Nao foi possivel recuperar o cadastro do Telefone.");
            }
        }
    }
}
