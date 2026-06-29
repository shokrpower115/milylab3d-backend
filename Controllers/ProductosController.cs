using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilyLab.API.DTOs;
using MilyLab.API.Services;

namespace MilyLab.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ProductoService _service;

    public ProductosController(ProductoService service)
    {
        _service = service;
    }

    // GET api/productos
    // GET api/productos?categoria=figuras
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? categoria)
    {
        var productos = await _service.GetAllAsync(categoria);
        return Ok(productos);
    }

    // GET api/productos/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var producto = await _service.GetByIdAsync(id);
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    // POST api/productos (solo admin)
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] ProductoCreateDTO dto)
    {
        var producto = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    // PUT api/productos/1 (solo admin)
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] ProductoUpdateDTO dto)
    {
        var producto = await _service.UpdateAsync(id, dto);
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    // DELETE api/productos/1 (solo admin)
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}