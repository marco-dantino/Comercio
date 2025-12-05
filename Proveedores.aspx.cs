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
    public partial class Proveedores : PageWithAuth
    {
        protected override int? RequiredRole => (int)RolUsuario.ADMIN;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }
        protected void gvProveedors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idProveedor = int.Parse(e.CommandArgument.ToString());
            ServiceProveedor Service = new ServiceProveedor();

            if (e.CommandName == "Editar")
            {
                Proveedor prov = Service.buscarPorId(idProveedor);

                ViewState["IdProveedorEdit"] = prov.Id;

                if (prov != null)
                {
                    txtCuitProveedorEdit.Text = prov.Cuit;
                    txtNombreProveedorEdit.Text = prov.Nombre;
                    txtDireccionEdit.Text = prov.Direccion;
                    txtTelefonoEdit.Text = prov.Telefono;
                    txtEmailEdit.Text = prov.Email;

                    panelEdit.Visible = true;
                }
                else
                {
                    lblMenssageStatus("Proveedor no encontrado.", "error");
                }
            }

            if (e.CommandName == "Eliminar")
            {
                Service.eliminar(idProveedor);

                lblMenssageStatus("Proveedor eliminado correctamente.", "error");

                cargarGrid();
            }
        }
        private void cargarGrid()
        {
            ServiceProveedor service = new ServiceProveedor();
            gvProveedor.DataSource = service.listar();
            gvProveedor.DataBind();
        }
        private void limpiarForm()
        {
            txtCuitProveedor.Text = "";
            txtNombreProveedor.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
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
        protected void btnAgregaProveedor_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor
            {
                Cuit = txtCuitProveedor.Text,
                Nombre = txtNombreProveedor.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,

                Activo = true
            };

            ServiceProveedor service = new ServiceProveedor();
            service.agregar(prov);

            lblMenssageStatus("Proveedor agregado exitosamente.");

            cargarGrid();
            limpiarForm();
        }
        protected void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor();
            prov.Id = (int)ViewState["IdProveedorEdit"];

            prov.Cuit = txtCuitProveedorEdit.Text;
            prov.Nombre = txtNombreProveedorEdit.Text;
            prov.Direccion = txtDireccionEdit.Text;
            prov.Telefono = txtTelefonoEdit.Text;
            prov.Email = txtEmailEdit.Text;

            prov.Activo = true;

            ServiceProveedor service = new ServiceProveedor();
            service.modificar(prov);

            lblMenssageStatus("Proveedor modificado correctamente.");

            cargarGrid();

            panelEdit.Visible = false;
        }
        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
        }
    }
}