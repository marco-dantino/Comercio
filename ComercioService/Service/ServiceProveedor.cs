using ComercioDomain;
using ComercioService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{
    public class ServiceProveedor
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta("SELECT id, cuit, nombre, direccion, telefono, email, activo FROM PROVEEDORES");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.Id = (int)datos.Reader["id"];
                    aux.Cuit = (string)datos.Reader["cuit"];
                    aux.Nombre = (string)datos.Reader["nombre"];
                    aux.Telefono = (string)datos.Reader["telefono"];
                    aux.Direccion = (string)datos.Reader["direccion"];
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

        public void agregar(Proveedor proveedor)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("INSERT INTO PROVEEDORES (cuit, nombre, direccion, telefono, email, activo) values (@cuit, @nombre, @direccion, @telefono, @email, @activo)");
                datos.setearParametro("@cuit", proveedor.Cuit);
                datos.setearParametro("@nombre", proveedor.Nombre);
                datos.setearParametro("@direccion", proveedor.Direccion);
                datos.setearParametro("@telefono", proveedor.Telefono);
                datos.setearParametro("@email", proveedor.Email);
                datos.setearParametro("@activo", proveedor.Activo);
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

        public void modificar(Proveedor cliente)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("UPDATE PROVEEDORES SET cuit = @cuit, nombre = @nombre, direccion = @direccion, telefono = @telefono, email = @email, activo = @activo where cuit = @cuit");
                datos.setearParametro("@cuit", cliente.Cuit);
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
                datos.setearConsulta("DELETE FROM PROVEEDORES WHERE id = @id");
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
