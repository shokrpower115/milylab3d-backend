using System;

namespace MilyLab.API.Models;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string ImagenUrl { get; set; } = string.Empty;
    public bool Disponible { get; set; } = true;
    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
}