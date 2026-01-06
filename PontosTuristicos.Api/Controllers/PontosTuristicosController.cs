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
        [FromQuery] int pagina = 1,
        [FromQuery] int tamanhoPagina = 10)
    {
        var pontos = await _service.ListarAsync(termo, pagina, tamanhoPagina);
        return Ok(pontos);
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
