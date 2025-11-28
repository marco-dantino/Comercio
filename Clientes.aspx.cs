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
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }
        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCliente = int.Parse(e.CommandArgument.ToString());
            ServiceCliente Service = new ServiceCliente();

            if (e.CommandName == "Editar")
            {
                Cliente client = Service.buscarPorId(idCliente);

                ViewState["IdClienteEdit"] = client.Id;

                if (client != null)
                {
                    txtDniEdit.Text = client.Dni.ToString();
                    txtNombreEdit.Text = client.Nombre;
                    txtDireccionEdit.Text = client.Direccion;
                    txtTelefonoEdit.Text = client.Telefono;
                    txtEmailEdit.Text = client.Email;

                    panelEdit.Visible = true;
                }
                else
                {
                    lblMenssageStatus("Cliente no encontrado.", "error");
                }
            }

            if (e.CommandName == "Eliminar")
            {
                Service.eliminar(idCliente);

                lblMenssageStatus("Cliente eliminado correctamente.", "error");

                cargarGrid();
            }
        }
        private void cargarGrid()
        {
            ServiceCliente service = new ServiceCliente();
            gvCliente.DataSource = service.listar();
            gvCliente.DataBind();
        }
        private void limpiarForm()
        {
            txtDniCliente.Text = "";
            txtNombreCliente.Text = "";
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
        protected void btnAgregaCliente_Click(object sender, EventArgs e)
        {
            ServiceCliente Service = new ServiceCliente();
            Cliente clienteActual = Service.buscarPorDni(int.Parse(txtDniCliente.Text));

            if (clienteActual != null)
            {
                lblMenssageStatus("El DNI cliente, ya existe.", "warning");
                return;
            }

            Cliente cliente = new Cliente
            {
                Dni = int.Parse(txtDniCliente.Text),
                Nombre = txtNombreCliente.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,

                Activo = true
            };

            ServiceCliente service = new ServiceCliente();
            service.agregar(cliente);

            lblMenssageStatus("Cliente agregado exitosamente.");

            cargarGrid();
            limpiarForm();
        }
        protected void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Id = (int)ViewState["IdClienteEdit"];

            cliente.Dni = int.Parse(txtDniEdit.Text);
            cliente.Nombre = txtNombreEdit.Text;
            cliente.Direccion = txtDireccionEdit.Text;
            cliente.Telefono = txtTelefonoEdit.Text;
            cliente.Email = txtEmailEdit.Text;

            cliente.Activo = true;

            ServiceCliente service = new ServiceCliente();
            service.modificar(cliente);

            lblMenssageStatus("Cliente modificado correctamente.");

            cargarGrid();

            panelEdit.Visible = false;
        }
        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
        }


    }
}