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
                ServiceProducto service = new ServiceProducto();
                var productos = service.listar();

                cargarMarcas();
                cargarCategorias();

                gvProductos.DataSource = productos;
                gvProductos.DataBind();
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
    }
}