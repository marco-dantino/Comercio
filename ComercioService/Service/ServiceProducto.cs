using ComercioDomain;
using ComercioService.DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{

    /// <summary>
    /// Hacer funcion, de activo y no activo.
    /// </summary>
    public class ServiceProducto
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta("SELECT PRODUCTOS.id, PRODUCTOS.nombre, PRODUCTOS.stock_actual, PRODUCTOS.precio_compra, PRODUCTOS.porcentaje_ganancia, PRODUCTOS.id_marca, PRODUCTOS.id_categoria, PRODUCTOS.activo, MARCAS.nombre AS nombreMarca, PRODUCTOS.imagen_url, CATEGORIAS.nombre AS nombreCategoria FROM PRODUCTOS JOIN MARCAS ON PRODUCTOS.id_marca = MARCAS.id JOIN CATEGORIAS ON PRODUCTOS.id_categoria = CATEGORIAS.id ORDER BY PRODUCTOS.id");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Reader["id"];
                    aux.Nombre = (string)datos.Reader["nombre"];
                    aux.StockActual = (int)datos.Reader["stock_actual"];
                    aux.PrecioCompra = (int)datos.Reader["precio_compra"];
                    aux.Ganancia = Convert.ToSingle(datos.Reader["porcentaje_ganancia"]);
                    
                    aux.Marca = new Marca();

                    aux.Marca.Id = (int)datos.Reader["id_marca"];
                    aux.Marca.Nombre = (string)datos.Reader["nombreMarca"];

                    aux.Categoria = new Categoria();

                    aux.Categoria.Id = (int)datos.Reader["id_categoria"];
                    aux.Categoria.Nombre = (string)datos.Reader["nombreCategoria"];

                    aux.ImagenUrl = (string)datos.Reader["imagen_url"];

                    aux.Activo = Convert.ToBoolean(datos.Reader["activo"]);
                    if (aux.Activo == true) lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Producto producto)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("INSERT into PRODUCTOS (nombre, stock_actual, precio_compra, porcentaje_ganancia, id_marca, id_categoria, activo, imagen_url) values (@nombre, @stock_actual, @precio_compra, @porcentaje_ganancia, @id_marca, @id_categoria, @activo, @imagen_url)");
                datos.setearParametro("@nombre", producto.Nombre);
                datos.setearParametro("@stock_actual", producto.StockActual);
                datos.setearParametro("@precio_compra", producto.PrecioCompra);
                datos.setearParametro("@porcentaje_ganancia", producto.Ganancia);
                datos.setearParametro("@id_marca", producto.Marca.Id);
                datos.setearParametro("@id_categoria", producto.Categoria.Id);
                datos.setearParametro("@imagen_url", producto.ImagenUrl);

                datos.setearParametro("@activo", producto.Activo);
                datos.ejecutarScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Producto producto)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("UPDATE PRODUCTOS SET nombre = @nombre, stock_actual = @stock_actual, precio_compra = @precio_compra, porcentaje_ganancia = @porcentaje_ganancia, id_marca = @id_marca, id_categoria = @id_categoria, imagen_url = @imagen_url, activo = @activo WHERE id = @id");
                datos.setearParametro("@id", producto.Id);
                datos.setearParametro("@nombre", producto.Nombre);
                datos.setearParametro("@stock_actual", producto.StockActual);
                datos.setearParametro("@precio_compra", producto.PrecioCompra);
                datos.setearParametro("@porcentaje_ganancia", producto.Ganancia);
                datos.setearParametro("@id_marca", producto.Marca.Id);
                datos.setearParametro("@id_categoria", producto.Categoria.Id);
                datos.setearParametro("@imagen_url", producto.ImagenUrl);

                datos.setearParametro("@activo", producto.Activo);
                datos.ejecutarScalar();
            }
            catch (Exception ex)
            {
                throw ex;
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
                datos.setearConsulta("DELETE FROM PROVEEDOR_PRODUCTO WHERE id_producto = @id ");
                datos.setearParametro("@id", id);

                datos.ejecutarScalar();

                datos.setearConsulta("DELETE FROM PRODUCTOS WHERE id = @id");
                datos.setearParametro("@id", id);
                
                datos.ejecutarScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Producto buscarPorNombre(string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT TOP 1 * FROM PRODUCTOS WHERE nombre = @nombre");
                datos.setearParametro("@nombre", nombre);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)datos.Reader["id"];
                    prod.Nombre = (string)datos.Reader["nombre"];

                    return prod;
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Producto buscarPorId(int id)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT PRODUCTOS.id, PRODUCTOS.nombre, PRODUCTOS.stock_actual, PRODUCTOS.precio_compra, PRODUCTOS.porcentaje_ganancia, PRODUCTOS.id_marca, PRODUCTOS.id_categoria, PRODUCTOS.activo, MARCAS.nombre AS nombreMarca, PRODUCTOS.imagen_url, CATEGORIAS.nombre AS nombreCategoria FROM PRODUCTOS JOIN MARCAS ON PRODUCTOS.id_marca = MARCAS.id JOIN CATEGORIAS ON PRODUCTOS.id_categoria = CATEGORIAS.id WHERE PRODUCTOS.id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)datos.Reader["id"];
                    prod.Nombre = (string)datos.Reader["nombre"];
                    prod.StockActual = (int)datos.Reader["stock_actual"];
                    prod.PrecioCompra = (int)datos.Reader["precio_compra"];
                    prod.Ganancia = Convert.ToSingle(datos.Reader["porcentaje_ganancia"]);

                    prod.Marca = new Marca();

                    prod.Marca.Id = (int)datos.Reader["id_marca"];
                    prod.Marca.Nombre = (string)datos.Reader["nombreMarca"];

                    prod.Categoria = new Categoria();

                    prod.Categoria.Id = (int)datos.Reader["id_categoria"];
                    prod.Categoria.Nombre = (string)datos.Reader["nombreCategoria"];

                    prod.ImagenUrl = (string)datos.Reader["imagen_url"];

                    prod.Activo = Convert.ToBoolean(datos.Reader["activo"]);
                    return prod;
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarProveedorProducto(int idProducto, int idProveedor)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("INSERT INTO PROVEEDOR_PRODUCTO (id_proveedor, id_producto) VALUES (@idProveedor, @idProducto)");
                datos.setearParametro("@idProveedor", idProveedor);
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizarProveedorProducto(int idProducto, int idProveedor)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("UPDATE PROVEEDOR_PRODUCTO SET id_proveedor = @idProveedor WHERE id_producto = @idProducto");
                datos.setearParametro("@idProveedor", idProveedor);
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarScalar();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Producto> listarPorProveedor(int idProveedor)
        {
            List<Producto> lista = new List<Producto>();
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta(@"SELECT PRODUCTOS.id, PRODUCTOS.nombre, PRODUCTOS.precio_compra FROM PRODUCTOS INNER JOIN PROVEEDOR_PRODUCTO ON PROVEEDOR_PRODUCTO.id_producto = PRODUCTOS.id WHERE PROVEEDOR_PRODUCTO.id_proveedor = @idProveedor");

                datos.setearParametro("@idProveedor", idProveedor);
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Producto aux = new Producto
                    {
                        Id = (int)datos.Reader["id"],
                        Nombre = datos.Reader["nombre"].ToString(),
                        PrecioCompra = float.Parse(datos.Reader["precio_compra"].ToString())
                    };

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }


        //public void activarProducto()
        //{
        //    DataAccess datos = new DataAccess();
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
    }
}
