using ComercioDomain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioDomain.Purchases
{
    public class DetalleCompra : DetalleBase
    {
        public Compra Compra { get; set; }
    }
}
