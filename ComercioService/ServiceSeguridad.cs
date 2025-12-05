using ComercioDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace ComercioService
{
    public class ServiceSeguridad
    {
        public static bool UsuarioLogueado(object user)
        {
            return user != null;
        }
        public static bool EsAdmin()
        {
            Usuario user = new Usuario();
            user = (Usuario)HttpContext.Current.Session["usuario"];
            return user != null && user.RolUsuario == RolUsuario.ADMIN;
        }
    }
}
