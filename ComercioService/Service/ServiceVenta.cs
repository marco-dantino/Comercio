using ComercioDomain;
using ComercioDomain.Purchases;
using ComercioDomain.Sales;
using ComercioService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{
    public class ServiceVenta
    {
        public List<Venta> listarPorUsuario(Usuario user)
        {
            DataAccess datos = new DataAccess();
            List<Venta> lista = new List<Venta>();

            try
            {
                datos.setearConsulta("SELECT VENTAS.id, VENTAS.fecha, VENTAS.total, VENTAS.numero_factura, CLIENTES.nombre AS nombre_cliente, USUARIOS.nombre AS nombre_usuario, VENTAS.id_usuario, VENTAS.id_cliente FROM VENTAS LEFT JOIN CLIENTES ON VENTAS.id_cliente = CLIENTES.id LEFT JOIN USUARIOS ON VENTAS.id_usuario = USUARIOS.id WHERE VENTAS.id_usuario = @IdUsuario;;");
                datos.setearParametro("@IdUsuario", user.Id);
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Venta aux = new Venta
                    {
                        Id = (int)datos.Reader["id"],
                        Fecha = (DateTime)datos.Reader["fecha"],
                        Total = Convert.ToSingle(datos.Reader["total"]),
                        NumeroFactura = datos.Reader["numero_factura"].ToString(),
                        DetallesCliente = new Cliente
                        {
                            Id = (int)datos.Reader["id_cliente"],
                            Nombre = datos.Reader["nombre_cliente"].ToString()
                        },
                        DetallesUsuario = new Usuario
                        {
                            Id = (int)datos.Reader["id_usuario"],
                            Nombre = datos.Reader["nombre_usuario"].ToString()
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

        public List<Venta> listarPorRango(int idUsuario, DateTime fechaDesde, DateTime fechaHasta)
        {
            DataAccess datos = new DataAccess();
            List<Venta> lista = new List<Venta>();

            try
            {
                datos.setearConsulta(@"SELECT VENTAS.id, VENTAS.fecha, VENTAS.total, VENTAS.numero_factura, CLIENTES.nombre AS nombre_cliente, USUARIOS.nombre AS nombre_usuario, VENTAS.id_usuario, VENTAS.id_cliente FROM VENTAS LEFT JOIN CLIENTES ON VENTAS.id_cliente = CLIENTES.id LEFT JOIN USUARIOS ON VENTAS.id_usuario = USUARIOS.id WHERE VENTAS.id_usuario = @IdUsuario AND VENTAS.fecha >= @FechaDesde AND VENTAS.fecha <= @FechaHasta");

                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@FechaDesde", fechaDesde.Date);
                datos.setearParametro("@FechaHasta", fechaHasta.Date);

                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Venta aux = new Venta
                    {
                        Id = (int)datos.Reader["id"],
                        Fecha = (DateTime)datos.Reader["fecha"],
                        Total = Convert.ToSingle(datos.Reader["total"]),
                        NumeroFactura = datos.Reader["numero_factura"].ToString(),
                        DetallesCliente = new Cliente
                        {
                            Id = (int)datos.Reader["id_cliente"],
                            Nombre = datos.Reader["nombre_cliente"].ToString()
                        },
                        DetallesUsuario = new Usuario
                        {
                            Id = (int)datos.Reader["id_usuario"],
                            Nombre = datos.Reader["nombre_usuario"].ToString()
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

        public List<Venta> listarPorFactura(int idUsuario, string numeroFactura)
        {
            DataAccess datos = new DataAccess();
            List<Venta> lista = new List<Venta>();

            try
            {
                datos.setearConsulta(@"SELECT VENTAS.id, VENTAS.fecha, VENTAS.total, VENTAS.numero_factura, CLIENTES.nombre AS nombre_cliente, USUARIOS.nombre AS nombre_usuario, VENTAS.id_usuario, VENTAS.id_cliente FROM VENTAS LEFT JOIN CLIENTES ON VENTAS.id_cliente = CLIENTES.id LEFT JOIN USUARIOS ON VENTAS.id_usuario = USUARIOS.id WHERE VENTAS.id_usuario = @IdUsuario AND VENTAS.numero_factura LIKE @NumeroFactura;");

                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@NumeroFactura", "%" + numeroFactura + "%"); // permite buscar parcialmente

                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Venta aux = new Venta
                    {
                        Id = (int)datos.Reader["id"],
                        Fecha = (DateTime)datos.Reader["fecha"],
                        Total = Convert.ToSingle(datos.Reader["total"]),
                        NumeroFactura = datos.Reader["numero_factura"].ToString(),
                        DetallesCliente = new Cliente
                        {
                            Id = (int)datos.Reader["id_cliente"],
                            Nombre = datos.Reader["nombre_cliente"].ToString()
                        },
                        DetallesUsuario = new Usuario
                        {
                            Id = (int)datos.Reader["id_usuario"],
                            Nombre = datos.Reader["nombre_usuario"].ToString()
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

        public int agregar(Venta venta, List<DetalleVenta> detalles)
        {
            DataAccess datos = new DataAccess();

            try
            {

                datos.setearConsulta(@"INSERT INTO VENTAS (fecha, total, numero_factura, id_cliente, id_usuario) VALUES (@fecha, @total, @numero_factura, @id_cliente, @id_usuario) SELECT CAST(SCOPE_IDENTITY() AS int);");

                datos.setearParametro("@fecha", venta.Fecha);
                datos.setearParametro("@total", venta.Total);
                datos.setearParametro("@numero_factura", venta.NumeroFactura);
                datos.setearParametro("@id_cliente", venta.DetallesCliente.Id);
                datos.setearParametro("@id_usuario", venta.DetallesUsuario.Id);

                int idVenta = Convert.ToInt32(datos.ejecutarScalar());

                foreach (var detalle in detalles)
                {
                    datos.setearConsulta(@"INSERT INTO DETALLE_VENTAS (cantidad, precio_unitario, id_venta, id_producto) VALUES (@cantidad, @precio_unitario, @id_venta, @id_producto)");

                    datos.setearParametro("@cantidad", detalle.Cantidad);
                    datos.setearParametro("@precio_unitario", detalle.PrecioUnitario);
                    datos.setearParametro("@id_venta", idVenta);
                    datos.setearParametro("@id_producto", detalle.Producto.Id);

                    datos.ejecutarScalar();
                }

                return idVenta;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //public void modificar(int id, DateTime fecha, float total, int proveedorID)
        //{
        //    DataAccess datos = new DataAccess();

        //    try
        //    {
        //        datos.setearConsulta(@"UPDATE COMPRAS SET fecha = @fecha, total = @total, id_proveedor = @id_proveedor WHERE id = @id");

        //        datos.setearParametro("@id", id);
        //        datos.setearParametro("@fecha", fecha);
        //        datos.setearParametro("@total", total);
        //        datos.setearParametro("@id_proveedor", proveedorID);

        //        datos.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
        public void eliminar(int id)
        {
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta("DELETE FROM DETALLE_VENTAS WHERE id_compra = @id");
                datos.setearParametro("@id", id);
                datos.ExecuteNonQuery();

                datos.setearConsulta("DELETE FROM VENTAS WHERE id = @id");
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
