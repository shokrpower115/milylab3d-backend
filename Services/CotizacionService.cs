using Microsoft.EntityFrameworkCore;
using MilyLab.API.Data;
using MilyLab.API.DTOs;
using MilyLab.API.Models;

namespace MilyLab.API.Services;

public class CotizacionService
{
    private readonly AppDbContext _context;

    public CotizacionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CotizacionResponseDTO>> GetAllAsync()
    {
        return await _context.Cotizaciones
            .OrderByDescending(c => c.CreadaEn)
            .Select(c => new CotizacionResponseDTO
            {
                Id = c.Id,
                NombreCliente = c.NombreCliente,
                Email = c.Email,
                Telefono = c.Telefono,
                Descripcion = c.Descripcion,
                ArchivoUrl = c.ArchivoUrl,
                Estado = c.Estado.ToString(),
                CreadaEn = c.CreadaEn
            }).ToListAsync();
    }

    public async Task<CotizacionResponseDTO> CreateAsync(CotizacionCreateDTO dto)
    {
        var cotizacion = new Cotizacion
        {
            NombreCliente = dto.NombreCliente,
            Email = dto.Email,
            Telefono = dto.Telefono,
            Descripcion = dto.Descripcion,
            ArchivoUrl = dto.ArchivoUrl
        };

        _context.Cotizaciones.Add(cotizacion);
        await _context.SaveChangesAsync();

        return new CotizacionResponseDTO
        {
            Id = cotizacion.Id,
            NombreCliente = cotizacion.NombreCliente,
            Email = cotizacion.Email,
            Telefono = cotizacion.Telefono,
            Descripcion = cotizacion.Descripcion,
            ArchivoUrl = cotizacion.ArchivoUrl,
            Estado = cotizacion.Estado.ToString(),
            CreadaEn = cotizacion.CreadaEn
        };
    }

    public async Task<bool> UpdateEstadoAsync(int id, EstadoCotizacion estado)
    {
        var cotizacion = await _context.Cotizaciones.FindAsync(id);
        if (cotizacion == null) return false;

        cotizacion.Estado = estado;
        await _context.SaveChangesAsync();
        return true;
    }
}