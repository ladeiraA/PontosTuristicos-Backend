using Microsoft.AspNetCore.Mvc;
using PontosTuristicos.Api.Models;
using PontosTuristicos.Api.Services;

namespace PontosTuristicos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PontosTuristicosController : ControllerBase
{
    private readonly PontoTuristicoService _service;

    public PontosTuristicosController(PontoTuristicoService service)
    {
        _service = service;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] string? termo,
        [FromQuery] string? search, // Alias para termo
        [FromQuery] int pagina = 0,
        [FromQuery] int page = 0, // Alias para pagina
        [FromQuery] int tamanhoPagina = 0,
        [FromQuery] int pageSize = 0) // Alias para tamanhoPagina
    {
        // Usar os valores enviados pelo frontend (priorizar inglês se ambos enviados)
        var paginaFinal = page > 0 ? page : (pagina > 0 ? pagina : 1);
        var tamanhoFinal = pageSize > 0 ? pageSize : (tamanhoPagina > 0 ? tamanhoPagina : 5);
        var termoFinal = !string.IsNullOrWhiteSpace(search) ? search : termo;

        // Validações básicas
        if (paginaFinal < 1) paginaFinal = 1;
        if (tamanhoFinal < 1) tamanhoFinal = 5;
        if (tamanhoFinal > 50) tamanhoFinal = 50; // Limite máximo

        var resultado = await _service.ListarAsync(termoFinal, paginaFinal, tamanhoFinal);
        return Ok(resultado);
    }

    // GET
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ponto = await _service.ObterPorIdAsync(id);

        if (ponto == null)
            return NotFound();

        return Ok(ponto);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PontoTuristico ponto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.CriarAsync(ponto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = ponto.Id },
            ponto);
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, PontoTuristico ponto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var atualizado = await _service.AtualizarAsync(id, ponto);

        if (!atualizado)
            return NotFound();

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _service.RemoverAsync(id);

        if (!removido)
            return NotFound();

        return NoContent();
    }

}
