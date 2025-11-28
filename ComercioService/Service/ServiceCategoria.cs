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
                datos.setearConsulta("DELETE FROM CATEGORIAS WHERE id = @id");
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

        public Categoria buscarPorNombre(string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT TOP 1 * FROM CATEGORIAS WHERE nombre = @nombre");
                datos.setearParametro("@nombre", nombre);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    Categoria cat = new Categoria();
                    cat.Id = (int)datos.Reader["id"];
                    cat.Nombre = (string)datos.Reader["nombre"];
                    return cat;
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Categoria buscarPorId(int id)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT TOP 1 * FROM CATEGORIAS WHERE id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)datos.Reader["id"];
                    categoria.Nombre = (string)datos.Reader["nombre"];

                    return categoria;
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
