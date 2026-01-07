using PontosTuristicos.Api.Models;
using PontosTuristicos.Api.Repositories;

namespace PontosTuristicos.Api.Services
{
    public class PontoTuristicoService
    {
        private readonly IPontoTuristicoRepository _repository;

        public PontoTuristicoService(IPontoTuristicoRepository repository)
        {
            _repository = repository;
        }

        public Task<PaginatedResult<PontoTuristico>> ListarAsync(
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

        public async Task<bool> AtualizarAsync(int id, PontoTuristico pontoAtualizado)
        {
            var ponto = await _repository.ObterPorIdAsync(id);
            if (ponto == null) return false;

            ponto.Nome = pontoAtualizado.Nome;
            ponto.Descricao = pontoAtualizado.Descricao;
            ponto.Referencia = pontoAtualizado.Referencia;
            ponto.Cidade = pontoAtualizado.Cidade;
            ponto.Estado = pontoAtualizado.Estado;

            await _repository.AtualizarAsync(ponto);
            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            return await _repository.RemoverAsync(id);
        }
    }
}