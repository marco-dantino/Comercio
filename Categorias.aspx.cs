using ComercioDomain;
using ComercioService;
using ComercioService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Categorias : PageWithAuth
    {
        protected override int? RequiredRole => (int)RolUsuario.ADMIN;
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
            int idCategoria = int.Parse(e.CommandArgument.ToString());
            ServiceCategoria Service = new ServiceCategoria();

            if (e.CommandName == "Editar")
            {
                Categoria categoria = Service.buscarPorId(idCategoria);

                ViewState["IdCategoriaEdit"] = categoria.Id;

                if (categoria != null)
                {
                    txtNombreEdit.Text = categoria.Nombre;

                    panelEdit.Visible = true;
                }
                else
                {
                    lblMenssageStatus("Categoria no encontrada.", "error");
                }
            }

            if (e.CommandName == "Eliminar")
            {    
                Service.eliminar(idCategoria);

                lblMenssageStatus("Categoria eliminada correctamente.", "error");

                cargarGrid();
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

        protected void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();

            categoria.Nombre = txtNombreEdit.Text;

            ServiceCategoria Service = new ServiceCategoria();
            Service.modificar(int.Parse(ViewState["IdCategoriaEdit"].ToString()), categoria.Nombre);

            lblMenssageStatus("Categoria modificada correctamente.");

            cargarGrid();

            panelEdit.Visible = false;
        }

        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
        }
    }
}