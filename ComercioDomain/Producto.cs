using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioDomain
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int StockActual { get; set; }
        public float PrecioCompra { get; set; }
        public float Ganancia { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public bool Activo { get; set; }
        public List<Imagen> Imagenes { get; set; }
    }
}
