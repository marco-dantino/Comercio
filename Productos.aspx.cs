using ComercioDomain;
using ComercioService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace Comercio
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
                cargarMarcas();
                cargarCategorias();
            }
        }

        private void cargarMarcas()
        {
            ServiceMarca Service = new ServiceMarca();
            List<Marca> marcas = Service.listar();

            ddlMarca.DataSource = marcas;
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem(string.Empty, "0"));
        }

        private void cargarCategorias()
        {
            ServiceCategoria categoriaNegocio = new ServiceCategoria();

            ddlCategoria.DataSource = categoriaNegocio.listar();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem(string.Empty, "0"));
        }

        protected void btnAgregaProducto_Click(object sender, EventArgs e)
        {
            if (ddlMarca.SelectedValue == "0")
            {
                rfvMarca.ErrorMessage = "Por favor, seleccione una marca válida.";
                rfvMarca.IsValid = false;

                return;
            }

            if (ddlCategoria.SelectedValue == "0")
            {
                rfvCategoria.ErrorMessage = "Por favor, seleccione una categoria válida.";
                rfvCategoria.IsValid = false;
                return;
            }

            ServiceProducto Service = new ServiceProducto();
            Producto newProducto = new Producto
            {
                Nombre = txtNombreProducto.Text,
                StockActual = int.Parse(txtStockActual.Text),
                PrecioCompra = int.Parse(txtPrecioCompra.Text),
                Ganancia = float.Parse(txtPorcentajeGanancia.Text),

                Marca = new Marca { Id = int.Parse(ddlMarca.SelectedValue) },
                Categoria = new Categoria { Id = int.Parse(ddlCategoria.SelectedValue) },

                ImagenUrl = txtImagenUrl.Text,

                Activo = true,
            };

            Producto productoActual = new Producto();
            productoActual = Service.buscarProductoPorId(newProducto.Id);

            if (productoActual.Nombre != null)
            {
                lblMessage.Text = "El producto ya existe.";
                lblMessage.CssClass = "text-danger";
            }
            else
            {
                Service.agregar(newProducto);
                lblMessage.Text = "Producto agregado exitosamente.";
                lblMessage.CssClass = "text-success";
            }
        }
        private void cargarGrid()
        {
            ServiceProducto service = new ServiceProducto();
            gvProductos.DataSource = service.listar();
            gvProductos.DataBind();
        }
        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Eliminar")
                {
                    ServiceProducto Service = new ServiceProducto();
                    Service.eliminar(idProducto);

                    lblMessage.Text = "Producto eliminado correctamente.";
                    lblMessage.CssClass = "text-success";

                    cargarGrid();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
        }
    }
}