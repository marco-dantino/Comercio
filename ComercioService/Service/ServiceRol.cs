using ComercioDomain;
using ComercioService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.Service
{
    public class ServiceRol
    {
        public List<Rol> listar()
        {
            List<Rol> lista = new List<Rol>();
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta("SELECT id, nombre FROM ROLES");
                datos.ejecutarLectura();

                while (datos.Reader.Read())
                {
                    Rol aux = new Rol();
                    aux.RolId = (int)datos.Reader["id"];
                    aux.RolNombre = (string)datos.Reader["nombre"];

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
    }
}
