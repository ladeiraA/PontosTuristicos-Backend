using Microsoft.EntityFrameworkCore;
using PontosTuristicos.Api.Data;
using PontosTuristicos.Api.Models;

namespace PontosTuristicos.Api.Repositories;

public class PontoTuristicoRepository : IPontoTuristicoRepository
{
    private readonly AppDbContext _context;

    public PontoTuristicoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<PontoTuristico>> ListarAsync(
        string? termo, int pagina, int tamanhoPagina)
    {
        var query = _context.PontosTuristicos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(termo))
        {
            var termoLower = termo.ToLower();
            query = query.Where(p =>
                p.Nome.ToLower().StartsWith(termoLower) ||
                p.Cidade.ToLower().StartsWith(termoLower) ||
                p.Estado.ToLower().StartsWith(termoLower));
        }

        // Contar total de registros
        var totalRegistros = await query.CountAsync();

        // Aplicar paginação e ordenação
        var dados = await query
            .OrderByDescending(p => p.DataInclusao)
            .Skip((pagina - 1) * tamanhoPagina)
            .Take(tamanhoPagina)
            .ToListAsync();

        return new PaginatedResult<PontoTuristico>
        {
            Items = dados,
            TotalItems = totalRegistros,
            CurrentPage = pagina,
            PageSize = tamanhoPagina
        };
    }

    public async Task<PontoTuristico?> ObterPorIdAsync(int id)
    {
        return await _context.PontosTuristicos.FindAsync(id);
    }

    public async Task AdicionarAsync(PontoTuristico ponto)
    {
        _context.PontosTuristicos.Add(ponto);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(PontoTuristico ponto)
    {
        _context.PontosTuristicos.Update(ponto);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var ponto = await _context.PontosTuristicos.FindAsync(id);
        if (ponto == null)
            return false;

        _context.PontosTuristicos.Remove(ponto);
        await _context.SaveChangesAsync();
        return true;
    }
}
