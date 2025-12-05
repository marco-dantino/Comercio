using ComercioService;
using ComercioDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Logout : PageWithAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string motivo = Request.QueryString["motivo"];

            if (motivo == "sinpermiso")
            {
                Response.Redirect("Default.aspx");
            } 
            else if (motivo == "logout") 
            { 
                Session.Remove("usuario");
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}