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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        private void cargarGrid()
        {
            ServiceCategoria service = new ServiceCategoria();
            gvCategorias.DataSource = service.listar();
            gvCategorias.DataBind();
        }
        private void limpiarForm()
        {
            txtNombreCategoria.Text = "";
        }

        protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idCategoria = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Eliminar")
                {
                    ServiceCategoria Service = new ServiceCategoria();
                    Service.eliminar(idCategoria);

                    lblMenssageStatus("Categoria eliminada correctamente.", "error");

                    cargarGrid();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
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

        protected void btnAgregaCategoria_Click(object sender, EventArgs e)
        {
            ServiceCategoria Service = new ServiceCategoria();
            Categoria CategoriaActual = Service.buscarPorNombre(txtNombreCategoria.Text);

            if (CategoriaActual != null)
            {
                lblMenssageStatus("La categoria ya existe.", "warning");
                return;
            }

            Service.agregar(txtNombreCategoria.Text);
            lblMenssageStatus("Categoria agregada exitosamente.");

            cargarGrid();
            limpiarForm();
        }
    }
}