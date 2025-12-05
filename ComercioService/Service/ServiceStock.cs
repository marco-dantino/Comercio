using ComercioDomain.Purchases;
using ComercioDomain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{
    public class ServiceStock
    {
        private ServiceProducto Service = new ServiceProducto();
        public bool ActualizarStock<T>(List<T> listaDetalle, string tipoOperacion)
        {
            if (tipoOperacion != "COMPRA" && tipoOperacion != "VENTA")
                return false;

            foreach (var detalle in listaDetalle)
            {
                int idProducto = 0;
                int cantidad = 0;

                if (detalle is DetalleCompra detalleCompra)
                {
                    idProducto = detalleCompra.Producto.Id;
                    cantidad = detalleCompra.Cantidad;
                }
                else if (detalle is DetalleVenta detalleVenta)
                {
                    idProducto = detalleVenta.Producto.Id;
                    cantidad = detalleVenta.Cantidad;
                }
                else
                {
                    throw new Exception("Tipo de detalle no soportado");
                }

                if (tipoOperacion == "COMPRA")
                {
                    Service.SumarStock(idProducto, cantidad);
                }
                else if (tipoOperacion == "VENTA")
                {
                    bool exito = Service.RestarStock(idProducto, cantidad);
                    if (!exito)
                        return false;
                        //throw new Exception($"Stock insuficiente para el producto con Id {idProducto}");
                }
            }

            return true;
        }
    }
}
