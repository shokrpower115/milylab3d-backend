using System;

namespace MilyLab.API.Models;

public class Cotizacion
{
    public int Id { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string? ArchivoUrl { get; set; }        // archivo STL opcional
    public EstadoCotizacion Estado { get; set; } = EstadoCotizacion.Pendiente;
    public DateTime CreadaEn { get; set; } = DateTime.UtcNow;
}

public enum EstadoCotizacion
{
    Pendiente,
    Revisada,
    Enviada,
    Aceptada,
    Rechazada
}