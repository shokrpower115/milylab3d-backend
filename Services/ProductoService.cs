using Microsoft.EntityFrameworkCore;
using MilyLab.API.Data;
using MilyLab.API.DTOs;
using MilyLab.API.Models;

namespace MilyLab.API.Services;

public class ProductoService
{
    private readonly AppDbContext _context;

    public ProductoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductoResponseDTO>> GetAllAsync(string? categoria = null)
    {
        var query = _context.Productos
            .Where(p => p.Disponible);

        if (!string.IsNullOrEmpty(categoria))
            query = query.Where(p => p.Categoria == categoria);

        return await query.Select(p => new ProductoResponseDTO
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Categoria = p.Categoria,
            Precio = p.Precio,
            ImagenUrl = p.ImagenUrl,
            Disponible = p.Disponible
        }).ToListAsync();
    }

    public async Task<ProductoResponseDTO?> GetByIdAsync(int id)
    {
        var p = await _context.Productos.FindAsync(id);
        if (p == null) return null;

        return new ProductoResponseDTO
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Categoria = p.Categoria,
            Precio = p.Precio,
            ImagenUrl = p.ImagenUrl,
            Disponible = p.Disponible
        };
    }

    public async Task<ProductoResponseDTO> CreateAsync(ProductoCreateDTO dto)
    {
        var producto = new Producto
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Categoria = dto.Categoria,
            Precio = dto.Precio,
            ImagenUrl = dto.ImagenUrl
        };

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return new ProductoResponseDTO
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            Categoria = producto.Categoria,
            Precio = producto.Precio,
            ImagenUrl = producto.ImagenUrl,
            Disponible = producto.Disponible
        };
    }

    public async Task<ProductoResponseDTO?> UpdateAsync(int id, ProductoUpdateDTO dto)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return null;

        if (dto.Nombre != null) producto.Nombre = dto.Nombre;
        if (dto.Descripcion != null) producto.Descripcion = dto.Descripcion;
        if (dto.Categoria != null) producto.Categoria = dto.Categoria;
        if (dto.Precio != null) producto.Precio = dto.Precio.Value;
        if (dto.ImagenUrl != null) producto.ImagenUrl = dto.ImagenUrl;
        if (dto.Disponible != null) producto.Disponible = dto.Disponible.Value;

        await _context.SaveChangesAsync();

        return new ProductoResponseDTO
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            Categoria = producto.Categoria,
            Precio = producto.Precio,
            ImagenUrl = producto.ImagenUrl,
            Disponible = producto.Disponible
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        producto.Disponible = false; // Soft delete
        await _context.SaveChangesAsync();
        return true;
    }
}