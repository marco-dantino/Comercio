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
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        protected void gvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idMarca = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Eliminar")
                {
                    ServiceMarca Service = new ServiceMarca();
                    Service.eliminar(idMarca);

                    lblMenssageStatus("Marca eliminada correctamente.", "error");

                    cargarGrid();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
        private void cargarGrid()
        {
            ServiceMarca service = new ServiceMarca();
            gvMarcas.DataSource = service.listar();
            gvMarcas.DataBind();
        }
        private void limpiarForm()
        {
            txtNombreMarca.Text = "";
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

        protected void btnAgregaMarca_Click(object sender, EventArgs e)
        {
            ServiceMarca Service = new ServiceMarca();
            Marca MarcaActual = Service.buscarPorNombre(txtNombreMarca.Text);

            if (MarcaActual != null)
            {
                lblMenssageStatus("La Marca ya existe.", "warning");
                return;
            }

            Service.agregar(txtNombreMarca.Text);
            lblMenssageStatus("Marca agregada exitosamente.");

            cargarGrid();
            limpiarForm();
        }
    }
}