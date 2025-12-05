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

            //validacion temporal (hacer validaciones)
            if (ddlProducto.SelectedValue == "" || txtCantidad.Text == "" || ddlCliente.SelectedValue == "") return;

            DetalleVenta detalle = new DetalleVenta();
            producto = Service.buscarPorId(int.Parse(ddlProducto.SelectedValue));
            
            detalle.Id = producto.Id;
            detalle.Cantidad = int.Parse(txtCantidad.Text);
            detalle.PrecioUnitario = producto.PrecioVenta;
            detalle.Producto = producto;

            ListaDetalle.Add(detalle);

            gvDetalleVenta.DataSource = ListaDetalle;
            gvDetalleVenta.DataBind();
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

            venta.DetallesCliente = cliente;
            venta.DetallesUsuario = new Usuario();

            venta.DetallesUsuario.Id = 1;
            venta.DetallesUsuario.Nombre = "Example Nombre";
            venta.DetallesUsuario.Apellido = "Example Apellido";
            venta.DetallesUsuario.Email = "marco.dantino@miasd.com";

            // TASK: update al stock actual de los productos
            // Cargar obj usuario logueado

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