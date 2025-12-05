using ComercioDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace ComercioService
{
    public class PageWithAuth : Page
    {
        protected virtual int? RequiredRole => null;
        protected override void OnLoad(EventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];

            if (RequiredRole != null && user.RolUsuario != RolUsuario.ADMIN)
            {
                Response.Redirect("Logout.aspx?motivo=sinpermiso");
            }

            if (!ServiceSeguridad.UsuarioLogueado(Session["usuario"]))
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            base.OnLoad(e);
        }
    }
}
