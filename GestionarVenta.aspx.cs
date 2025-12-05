using ComercioDomain;
using ComercioDomain.Purchases;
using ComercioDomain.Sales;
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
    public partial class GestionarVenta : PageWithAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                cargarProductos();
                cargarClientes();
            }   
        }
        private void cargarProductos()
        {
            ddlProducto.DataSource = new ServiceProducto().listar();
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "Id";
            ddlProducto.DataBind();

            ddlProducto.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        private void cargarClientes()
        {
            ddlCliente.DataSource = new ServiceCliente().listar();
            ddlCliente.DataTextField = "Nombre";
            ddlCliente.DataValueField = "Id";
            ddlCliente.DataBind();
            
            ddlCliente.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        private List<DetalleVenta> ListaDetalle
        {
            get
            {
                if (Session["DetalleVenta"] == null)
                    Session["DetalleVenta"] = new List<DetalleVenta>();

                return (List<DetalleVenta>)Session["DetalleVenta"];
            }
            set { Session["DetalleVenta"] = value; }
        }
        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            ServiceProducto Service = new ServiceProducto();
            Producto producto = new Producto();

            //validacion temporal
            if (ddlProducto.SelectedValue == "" || txtCantidad.Text == "" || ddlCliente.SelectedValue == "") return;

            DetalleVenta detalle = new DetalleVenta();
            producto = Service.buscarPorId(int.Parse(ddlProducto.SelectedValue));
            
            if(producto.StockActual < int.Parse(txtCantidad.Text)) 
            {
                lblMenssageStatus($"Stock insuficiente para el producto {producto.Nombre}. Stock disponible: {producto.StockActual}", "error");
                return;
            }

            detalle.Id = producto.Id;
            detalle.Cantidad = int.Parse(txtCantidad.Text);
            detalle.PrecioUnitario = producto.PrecioVenta;
            detalle.Producto = producto;

            ListaDetalle.Add(detalle);

            gvDetalleVenta.DataSource = ListaDetalle;
            gvDetalleVenta.DataBind();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ServiceVenta Service = new ServiceVenta();
            ServiceCliente serviceCliente = new ServiceCliente();

            Venta venta = new Venta();
            venta.Fecha = DateTime.Parse(txtFecha.Text);
            venta.Total = ListaDetalle.Sum(x => x.Subtotal);
            
            int idCliente = int.Parse(ddlCliente.SelectedValue);
            Cliente cliente = new Cliente();
            cliente = serviceCliente.buscarPorId(idCliente);
            cliente.Id = idCliente;

            Usuario user = (Usuario)Session["usuario"];

            venta.DetallesCliente = cliente;
            venta.DetallesUsuario = new Usuario();

            venta.DetallesUsuario.Id = user.Id;
            venta.DetallesUsuario.Nombre = user.Nombre;
            venta.DetallesUsuario.Apellido = user.Apellido;
            venta.DetallesUsuario.Email = user.Email;

            ServiceStock stockService = new ServiceStock();
            stockService.ActualizarStock(ListaDetalle, "VENTA");

            int idVenta = Service.agregar(venta, ListaDetalle);

            Session.Remove("DetalleVenta");
            gvDetalleVenta.DataSource = null;
            gvDetalleVenta.DataBind();
        }

        protected void gvDetalleVenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                ListaDetalle.RemoveAt(index);

                gvDetalleVenta.DataSource = ListaDetalle;
                gvDetalleVenta.DataBind();
            }
        }
    }
}