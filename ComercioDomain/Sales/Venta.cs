using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioDomain.Sales
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public string NumeroFactura { get; set; } = $"FAC-{DateTime.Now.Year}-{DateTime.Now.Ticks}";
        public Cliente DetallesCliente { get; set; }
        public Usuario DetallesUsuario { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
    }
}
