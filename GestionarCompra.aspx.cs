using ComercioDomain;
using ComercioDomain.Purchases;
using ComercioService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class GestionarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProveedores();
            }
        }

        private void cargarProveedores()
        {
            ddlProveedor.DataSource = new ServiceProveedor().listar();
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "Id";
            ddlProveedor.DataBind();

            ddlProveedor.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        protected void gvDetalleCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                ListaDetalle.RemoveAt(index);

                gvDetalleCompra.DataSource = ListaDetalle;
                gvDetalleCompra.DataBind();
            }
        }
        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProveedor = int.Parse(ddlProveedor.SelectedValue);

            ServiceProducto service = new ServiceProducto();

            ddlProducto.DataSource = service.listarPorProveedor(idProveedor);
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "Id";
            ddlProducto.DataBind();

            ddlProducto.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        private List<DetalleCompra> ListaDetalle
        {
            get
            {
                if (Session["DetalleCompra"] == null)
                    Session["DetalleCompra"] = new List<DetalleCompra>();

                return (List<DetalleCompra>)Session["DetalleCompra"];
            }
            set { Session["DetalleCompra"] = value; }
        }
        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            //validacion temporal (hacer validaciones)
            if (ddlProducto.SelectedValue == "" || txtCantidad.Text == "" || txtPrecioCompra.Text == "") return;

            DetalleCompra detalle = new DetalleCompra();
            detalle.Id = int.Parse(ddlProducto.SelectedValue);
            detalle.Producto = new Producto { Id = int.Parse(ddlProducto.SelectedValue) , Nombre = ddlProducto.SelectedItem.Text };
            detalle.Cantidad = int.Parse(txtCantidad.Text);
            detalle.PrecioUnitario = float.Parse(txtPrecioCompra.Text);

            ListaDetalle.Add(detalle);

            gvDetalleCompra.DataSource = ListaDetalle;
            gvDetalleCompra.DataBind();

            txtCantidad.Text = "";
            txtPrecioCompra.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ServiceCompra Service = new ServiceCompra();

            Compra compra = new Compra();
            compra.Fecha = DateTime.Parse(txtFecha.Text);
            compra.Total = ListaDetalle.Sum(x => x.Subtotal);
            compra.Proveedor = new Proveedor { Id = int.Parse(ddlProveedor.SelectedValue) };

            // TASK: update al stock actual de los productos

            int idCompra = Service.agregar(compra, ListaDetalle);

            Session.Remove("DetalleCompra");
            gvDetalleCompra.DataSource = null;
            gvDetalleCompra.DataBind();
        }
    }
}