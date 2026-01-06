using PontosTuristicos.Api.Models;

namespace PontosTuristicos.Api.Repositories;

public interface IPontoTuristicoRepository
{
    Task<IEnumerable<PontoTuristico>> ListarAsync(
        string? termo,
        int pagina,
        int tamanhoPagina);

    Task<PontoTuristico?> ObterPorIdAsync(int id);

    Task AdicionarAsync(PontoTuristico ponto);
    Task AtualizarAsync(PontoTuristico ponto);
    Task<bool> RemoverAsync(int id);
}
