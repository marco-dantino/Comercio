using ComercioDomain;
using ComercioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class _Default : PageWithAuth
    {
        public bool UsuarioEsAdmin => ServiceSeguridad.EsAdmin();
        public string NombreUsuario
        {
            get
            {
                Usuario nombreUser = (Usuario)Session["usuario"];
                return nombreUser != null ? nombreUser.Nombre : "";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}