using ComercioDomain;
using ComercioService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{
    public class ServiceUsuario
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta("SELECT USUARIOS.id, USUARIOS.nombre, USUARIOS.apellido, USUARIOS.email, password, ROLES.id AS RolId, ROLES.nombre AS RolNombre FROM USUARIOS INNER JOIN ROLES ON ROLES.id = USUARIOS.id_rol;");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Reader["id"];
                    aux.Nombre = (string)datos.Reader["nombre"];
                    aux.Apellido = (string)datos.Reader["apellido"];
                    aux.Email = (string)datos.Reader["email"];
                    aux.Password = (string)datos.Reader["password"];

                    aux.Rol = new Rol();
                    aux.Rol.RolId = (int)datos.Reader["RolId"];
                    aux.Rol.RolNombre = (string)datos.Reader["RolNombre"];

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

        public void agregar(Usuario usuario)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("INSERT INTO USUARIOS (nombre, apellido, email, password, id_rol) VALUES (@nombre, @apellido, @email, @password, @rol)");
                
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@password", usuario.Password);
                datos.setearParametro("@rol", usuario.Rol.RolId);

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

        public void modificar(Usuario usuario)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("UPDATE USUARIOS SET nombre = @nombre, apellido = @apellido, email = @email, password = @password, id_rol = @idRol WHERE id = @id");

                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@password", usuario.Password);
                datos.setearParametro("@id_rol", usuario.Rol.RolId);

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
                datos.setearConsulta("DELETE FROM USUARIOS WHERE id = @id");
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

        public Usuario buscarPorNombre(string nombre)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT TOP 1 * FROM USUARIOS WHERE nombre = @nombre");
                datos.setearParametro("@nombre", nombre);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    Usuario user = new Usuario();
                    user.Id = (int)datos.Reader["id"];
                    user.Nombre = (string)datos.Reader["nombre"];

                    return user;
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
