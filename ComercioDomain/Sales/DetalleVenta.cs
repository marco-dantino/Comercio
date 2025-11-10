using ComercioDomain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioDomain.Sales
{
    public class DetalleVenta : DetalleBase
    {
        public Venta Venta{ get; set; }
        public float CalcularPrecioVenta(Producto producto)
        {
            return producto.PrecioCompra * (1 + producto.Ganancia);
        }

    }
}
