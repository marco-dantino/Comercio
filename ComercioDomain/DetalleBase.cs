using ComercioDomain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioDomain
{
    public class DetalleBase
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public Producto Producto { get; set; }
        public float Subtotal => Cantidad * PrecioUnitario;
    }
}
