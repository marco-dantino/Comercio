using ComercioDomain;
using ComercioDomain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioDomain.Purchases
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<DetalleCompra> Detalles { get; set; }
    }
}
