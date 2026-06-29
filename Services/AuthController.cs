using Microsoft.AspNetCore.Mvc;
using MilyLab.API.DTOs;
using MilyLab.API.Services;

namespace MilyLab.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _service;

    public AuthController(AuthService service)
    {
        _service = service;
    }

    // POST api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
    {
        var result = await _service.LoginAsync(dto);
        if (result == null) return Unauthorized(new { message = "Credenciales incorrectas" });
        return Ok(result);
    }

    // POST api/auth/register (solo para setup inicial)
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginRequestDTO dto)
    {
        var result = await _service.RegisterAsync(dto.Email, dto.Password);
        if (!result) return Conflict(new { message = "El usuario ya existe" });
        return Ok(new { message = "Usuario creado correctamente" });
    }
}