using ComercioDomain;
using ComercioService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{
    public class ServiceCategoria
    {
        public List<Categoria> listar()
        {
            DataAccess datos = new DataAccess();
            List<Categoria> lista = new List<Categoria>();

            try
            {
                datos.setearConsulta("SELECT id, nombre FROM CATEGORIAS ORDER BY id");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Categoria aux = new Categoria();
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
                datos.setearConsulta("INSERT INTO CATEGORIAS (nombre) values (@nombre)");
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
                datos.setearConsulta("UPDATE CATEGORIAS SET nombre = @nombre where id = @id");
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
    }
}
