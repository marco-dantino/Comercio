using ComercioDomain;
using ComercioService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{
    public class ServiceCliente
    {
        public List<Cliente> listar()
        {
            DataAccess datos = new DataAccess();
            List<Cliente> lista = new List<Cliente>();

            try
            {
                datos.setearConsulta("SELECT id, dni, nombre, direccion, telefono, email, activo FROM CLIENTES");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)datos.Reader["id"];
                    aux.Dni = (int)datos.Reader["dni"];
                    aux.Nombre = (string)datos.Reader["nombre"];
                    aux.Telefono = (string)datos.Reader["telefono"];
                    aux.Direccion= (string)datos.Reader["direccion"];
                    aux.Email = (string)datos.Reader["email"];

                    aux.Activo = Convert.ToBoolean(datos.Reader["activo"]);
                    if (aux.Activo == true) lista.Add(aux);
                }

                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregar(Cliente cliente)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("INSERT INTO CLIENTES (nombre, direccion, telefono, email, dni, activo) values (@nombre, @direccion, @telefono, @email, @dni, @activo)");
                datos.setearParametro("@dni", cliente.Dni);
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@direccion", cliente.Direccion);
                datos.setearParametro("@telefono", cliente.Telefono);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@activo", cliente.Activo);
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

        public void modificar(Cliente cliente)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("UPDATE CLIENTES SET dni = @dni, nombre = @nombre, direccion = @direccion, telefono = @telefono, email = @email, activo = @activo where id = @id");
                datos.setearParametro("@id", cliente.Id);
                datos.setearParametro("@dni", cliente.Dni);
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@direccion", cliente.Direccion);
                datos.setearParametro("@telefono", cliente.Telefono);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@activo", cliente.Activo);
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
                datos.setearConsulta("DELETE FROM CLIENTES WHERE id = @id");
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
        public Cliente buscarPorDni(int dni)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT TOP 1 * FROM CLIENTES WHERE dni = @dni");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    Cliente client = new Cliente();
                    client.Id = (int)datos.Reader["id"];
                    client.Dni = (int)datos.Reader["dni"];

                    return client;
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Cliente buscarPorId(int id)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("SELECT TOP 1 * FROM CLIENTES WHERE id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Reader.Read())
                {
                    Cliente client = new Cliente();
                    client.Id = (int)datos.Reader["id"];
                    client.Dni = (int)datos.Reader["dni"];
                    client.Nombre = (string)datos.Reader["nombre"];
                    client.Telefono = (string)datos.Reader["telefono"];
                    client.Direccion = (string)datos.Reader["direccion"];
                    client.Email = (string)datos.Reader["email"];

                    return client;
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
