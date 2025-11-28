using ComercioDomain;
using ComercioDomain.Purchases;
using ComercioService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{
    public class ServiceCompra
    {
        public List<Compra> listar()
        {
            DataAccess datos = new DataAccess();
            List<Compra> lista = new List<Compra>();

            try
            {
                datos.setearConsulta("SELECT id, fecha, total, proveedor_id FROM COMPRAS");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Compra aux = new Compra
                    {
                        Id = (int)datos.Reader["id"],
                        Fecha = (DateTime)datos.Reader["fecha"],
                        Total = Convert.ToSingle(datos.Reader["total"]),
                        Proveedor = new Proveedor
                        {
                            Id = (int)datos.Reader["proveedor_id"]
                        }
                    };

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        public int agregar(Compra compra, List<DetalleCompra> detalles)
        {
            DataAccess datos = new DataAccess();

            try
            {
                
                datos.setearConsulta(@"INSERT INTO COMPRAS (fecha, total, id_proveedor) VALUES (@fecha, @total, @id_proveedor) SELECT CAST(SCOPE_IDENTITY() AS int);");

                datos.setearParametro("@fecha", compra.Fecha);
                datos.setearParametro("@total", compra.Total);
                datos.setearParametro("@id_proveedor", compra.Proveedor.Id);

                int idCompra = Convert.ToInt32(datos.ejecutarScalar());

                foreach (var detalle in detalles)
                {
                    datos.setearConsulta(@"INSERT INTO DETALLE_COMPRAS (cantidad, precio_unitario, id_compra, id_producto)VALUES (@cantidad, @precio_unitario, @id_compra, @id_producto)");

                    datos.setearParametro("@cantidad", detalle.Cantidad);
                    datos.setearParametro("@precio_unitario", detalle.PrecioUnitario);
                    datos.setearParametro("@id_compra", idCompra);
                    datos.setearParametro("@id_producto", detalle.Producto.Id);

                    datos.ejecutarScalar();

                }
                
                return idCompra;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        public void modificar(int id, DateTime fecha, float total, int proveedorID)
        {
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta(@"UPDATE COMPRAS SET fecha = @fecha, total = @total, id_proveedor = @id_proveedor WHERE id = @id");

                datos.setearParametro("@id", id);
                datos.setearParametro("@fecha", fecha);
                datos.setearParametro("@total", total);
                datos.setearParametro("@id_proveedor", proveedorID);

                datos.ExecuteNonQuery();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta("DELETE FROM DETALLES_COMPRAS WHERE id_compra = @id");
                datos.setearParametro("@id", id);
                datos.ExecuteNonQuery();

                datos.setearConsulta("DELETE FROM COMPRAS WHERE id = @id");
                datos.setearParametro("@id", id);
                datos.ExecuteNonQuery();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
