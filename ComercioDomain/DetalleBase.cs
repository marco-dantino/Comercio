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

        //Precio unitario de compra (ultimo precio al que se compro) o venta (precio real + %ganancia) segun corresponda
        public float PrecioUnitario { get; set; }
        public Producto Producto { get; set; }

        //validacion si es requerido
        public float Subtotal => Cantidad * PrecioUnitario;
    }
}
