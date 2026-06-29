namespace MilyLab.API.DTOs;

public class CotizacionResponseDTO
{
    public int Id { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string? ArchivoUrl { get; set; }
    public string Estado { get; set; } = string.Empty;
    public DateTime CreadaEn { get; set; }
}

public class CotizacionCreateDTO
{
    public string NombreCliente { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string? ArchivoUrl { get; set; }
}