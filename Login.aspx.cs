using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComercioDomain;
using ComercioService.Service;

namespace Comercio
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void lblMenssageStatus(string mensaje, string type = "success")
        {
            lblMessage.Text = mensaje;

            if (type == "error")
            {
                lblMessage.CssClass = "block px-4 py-2 rounded-md bg-red-900 text-red-300 border border-red-700 font-medium";
            }
            else if (type == "warning")
            {
                lblMessage.CssClass = "block px-4 py-2 rounded-md bg-yellow-900 text-yellow-300 border border-yellow-700 font-medium";
            }
            else
            {
                lblMessage.CssClass = "block px-4 py-2 rounded-md bg-green-900 text-green-300 border border-green-700 font-medium";
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario user;
            ServiceUsuario Service = new ServiceUsuario();

            try
            {
                user = new Usuario(txtEmail.Text, txtClave.Text, false);
                if (Service.Login(user)) 
                {
                    Session.Add("usuario", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblMenssageStatus("Usuario o contraseña incorrecta.", "error");
                    return;
                }


                Response.Cookies.Clear();
            }
            catch (Exception ex)
            {
                lblMenssageStatus("ERROR EXCEPTION", "error");
            }
        }
    }
}