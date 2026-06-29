using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilyLab.API.DTOs;
using MilyLab.API.Models;
using MilyLab.API.Services;

namespace MilyLab.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CotizacionesController : ControllerBase
{
    private readonly CotizacionService _service;

    public CotizacionesController(CotizacionService service)
    {
        _service = service;
    }

    // GET api/cotizaciones (solo admin)
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var cotizaciones = await _service.GetAllAsync();
        return Ok(cotizaciones);
    }

    // POST api/cotizaciones (público)
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CotizacionCreateDTO dto)
    {
        var cotizacion = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = cotizacion.Id }, cotizacion);
    }

    // PATCH api/cotizaciones/1/estado (solo admin)
    [HttpPatch("{id}/estado")]
    [Authorize]
    public async Task<IActionResult> UpdateEstado(int id, [FromBody] EstadoCotizacion estado)
    {
        var result = await _service.UpdateEstadoAsync(id, estado);
        if (!result) return NotFound();
        return NoContent();
    }
}