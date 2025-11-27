using ComercioDomain;
using ComercioService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{
    public class ServiceMarca
    {
        public List<Marca> listar()
        {
            DataAccess datos = new DataAccess();
            List<Marca> lista = new List<Marca>();

            try
            {
                datos.setearConsulta("SELECT id, nombre FROM MARCAS ORDER BY id");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Reader["id"];
                    aux.Nombre = datos.Reader["nombre"].ToString();

                    lista.Add(aux);
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

        public void agregar(string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("INSERT INTO MARCAS (nombre) values (@nombre)");
                datos.setearParametro("@nombre", nombre);
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

        public void modificar(int id, string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("UPDATE MARCAS SET nombre = @nombre where id = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@nombre", nombre);
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
                datos.setearConsulta("DELETE FROM MARCAS WHERE id = @id");
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
        public Marca buscarPorNombre(string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT TOP 1 * FROM MARCAS WHERE nombre = @nombre");
                datos.setearParametro("@nombre", nombre);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Reader["id"];
                    marca.Nombre = (string)datos.Reader["nombre"];
                    return marca;
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
