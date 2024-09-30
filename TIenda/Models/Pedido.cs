namespace TIenda.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; } // ID único del pedido
        public DateTime Fecha { get; set; } // Fecha del pedido
        public decimal Total { get; set; } // Total del pedido
    }
}
