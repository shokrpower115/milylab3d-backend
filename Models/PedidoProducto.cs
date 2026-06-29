using System;

namespace MilyLab.API.Models;

public class PedidoProducto
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    // Relaciones
    public Pedido Pedido { get; set; } = null!;
    public Producto Producto { get; set; } = null!;
}