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
            int idMarca = int.Parse(e.CommandArgument.ToString());
            ServiceMarca Service = new ServiceMarca();

            if (e.CommandName == "Editar")
            {
                Marca marca = Service.buscarPorId(idMarca);

                ViewState["IdMarcaEdit"] = marca.Id;

                if (marca != null)
                {
                    txtNombreEdit.Text = marca.Nombre;

                    panelEdit.Visible = true;
                }
                else
                {
                    lblMenssageStatus("Marca no encontrada.", "error");
                }
            }
            
            if (e.CommandName == "Eliminar")
            {
                Service.eliminar(idMarca);

                lblMenssageStatus("Marca eliminada correctamente.", "error");

                cargarGrid();
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


        protected void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();

            marca.Nombre = txtNombreEdit.Text;

            ServiceMarca Service = new ServiceMarca();
            Service.modificar(int.Parse(ViewState["IdMarcaEdit"].ToString()), marca.Nombre);

            lblMenssageStatus("Marca modificada correctamente.");

            cargarGrid();

            panelEdit.Visible = false;
        }
        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
        }
    }
}