using PontosTuristicos.Api.Models;
using PontosTuristicos.Api.Repositories;

namespace PontosTuristicos.Api.Services;

public class PontoTuristicoService
{
    private readonly IPontoTuristicoRepository _repository;

    public PontoTuristicoService(IPontoTuristicoRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<PontoTuristico>> ListarAsync(
        string? termo, int pagina, int tamanhoPagina)
    {
        return _repository.ListarAsync(termo, pagina, tamanhoPagina);
    }

    public Task<PontoTuristico?> ObterPorIdAsync(int id)
    {
        return _repository.ObterPorIdAsync(id);
    }

    public Task CriarAsync(PontoTuristico ponto)
    {
        ponto.DataInclusao = DateTime.Now;
        return _repository.AdicionarAsync(ponto);
    }
}
