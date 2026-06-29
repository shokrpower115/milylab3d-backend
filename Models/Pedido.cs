using System;

namespace MilyLab.API.Models;

public class Pedido
{
    public int Id { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public EstadoPedido Estado { get; set; } = EstadoPedido.Pendiente;
    public string? MercadoPagoId { get; set; }     // ID de pago externo
    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

    // Relación
    public List<PedidoProducto> Productos { get; set; } = new();
}

public enum EstadoPedido
{
    Pendiente,
    Pagado,
    EnProduccion,
    Enviado,
    Entregado,
    Cancelado
}