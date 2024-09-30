using System;

namespace TIenda.Models
{
    public class DetallePedido
    {
        public int IdDetalle { get; set; } // Esta es la columna de identidad
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

}
