using ComercioDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //ID de los a para cuando la session en User o ADM cambiar visibilidad,
            //Pero la visibilidad no garantiza la seguridad de ingreso de ruta.
            ///Antes de cargar la pagina que usuario o Adm intenta acceder, validar rol.
            //LinkProducts.Visible = false;
        }
    }
}