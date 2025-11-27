using ComercioDomain;
using ComercioService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarRoles();

                cargarGrid();
            }
        }
        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Eliminar")
                {
                    ServiceUsuario Service = new ServiceUsuario();
                    Service.eliminar(idUsuario);

                    lblMenssageStatus("Usuario eliminado correctamente.", "error");

                    cargarGrid();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
        protected void btnAgregaProveedor_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario
            {
                Nombre = txtNombreUsuario.Text,
                Apellido = txtApellidoUsuario.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                Rol = new Rol { RolId = int.Parse(ddlRol.SelectedValue) },
            };

            ServiceUsuario service = new ServiceUsuario();
            service.agregar(user);

            lblMenssageStatus("Producto agregado exitosamente.");

            cargarGrid();
            limpiarForm();
        }
        private void cargarGrid()
        {
            ServiceUsuario service = new ServiceUsuario();
            gvUsuarios.DataSource = service.listar();
            gvUsuarios.DataBind();
        }
        private void limpiarForm()
        {
            txtNombreUsuario.Text = "";
            txtApellidoUsuario.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            ddlRol.SelectedIndex = 0;
        }
        private void lblMenssageStatus(string mensaje, string type = "success")
        {
            lblMessage.Text = mensaje;

            if (type == "error")
            {
                lblMessage.CssClass = "block mt-4 px-4 py-2 rounded-md bg-red-900 text-red-300 border border-red-700 font-medium";
            }
            else if (type == "warning")
            {
                lblMessage.CssClass = "block mt-4 px-4 py-2 rounded-md bg-yellow-900 text-yellow-300 border border-yellow-700 font-medium";
            }
            else
            {
                lblMessage.CssClass = "block mt-4 px-4 py-2 rounded-md bg-green-900 text-green-300 border border-green-700 font-medium";
            }
        }

        private void cargarRoles()
        {
            ServiceRol service = new ServiceRol();
            ddlRol.DataSource = service.listar();
            ddlRol.DataTextField = "RolNombre";
            ddlRol.DataValueField = "RolId";
            ddlRol.DataBind();
        }
    }
}
    