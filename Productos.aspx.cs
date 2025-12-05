using ComercioDomain;
using ComercioService;
using ComercioService.Service;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Productos : PageWithAuth
    {
        public bool UsuarioEsAdmin => ServiceSeguridad.EsAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvProductos.Columns[8].Visible = UsuarioEsAdmin;
                cargarGrid();

                cargarMarcas();
                cargarCategorias();

                cargarProveedores();
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
            
            ddlMarcaEdit.DataSource = marcas;
            ddlMarcaEdit.DataTextField = "Nombre";
            ddlMarcaEdit.DataValueField = "Id";
            ddlMarcaEdit.DataBind();
            ddlMarcaEdit.Items.Insert(0, new ListItem(string.Empty, "0"));
        }
        private void cargarCategorias()
        {
            ServiceCategoria categoriaNegocio = new ServiceCategoria();

            ddlCategoria.DataSource = categoriaNegocio.listar();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem(string.Empty, "0"));
            
            ddlCategoriaEdit.DataSource = categoriaNegocio.listar();
            ddlCategoriaEdit.DataTextField = "Nombre";
            ddlCategoriaEdit.DataValueField = "Id";
            ddlCategoriaEdit.DataBind();
            ddlCategoriaEdit.Items.Insert(0, new ListItem(string.Empty, "0"));
        }
        private void cargarProveedores()
        {
            ServiceProveedor categoriaProveedor = new ServiceProveedor();

            ddlProveedor.DataSource = categoriaProveedor.listar();
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "Id";
            ddlProveedor.DataBind();
            ddlProveedor.Items.Insert(0, new ListItem(string.Empty, "0"));
            
            ddlProveedorEdit.DataSource = categoriaProveedor.listar();
            ddlProveedorEdit.DataTextField = "Nombre";
            ddlProveedorEdit.DataValueField = "Id";
            ddlProveedorEdit.DataBind();
            ddlProveedorEdit.Items.Insert(0, new ListItem(string.Empty, "0"));
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
            Producto productoActual = Service.buscarPorNombre(txtNombreProducto.Text);

            if (productoActual != null)
            {
                lblMenssageStatus("El producto ya existe.", "warning");
                return;
            }
            
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
           
            Service.agregar(newProducto);

            Producto productoAgregado = Service.buscarPorNombre(newProducto.Nombre);

            int idProveedor = int.Parse(ddlProveedor.SelectedValue);

            //Puede tener o no proveedor(? VALIDAR
            if (idProveedor > 0)
            {
                Service.agregarProveedorProducto(productoAgregado.Id, idProveedor);
            }

            lblMenssageStatus("Producto agregado exitosamente.");

            cargarGrid();
            limpiarForm();
        }
        private void cargarGrid()
        {
            ServiceProducto service = new ServiceProducto();
            gvProductos.DataSource = service.listar();
            gvProductos.DataBind();
        }
        private void limpiarForm() 
        {
            txtNombreProducto.Text = "";
            txtStockActual.Text = "";
            txtPrecioCompra.Text = "";
            txtPorcentajeGanancia.Text = "";
            ddlMarca.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
            txtImagenUrl.Text = "";
        }
        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);
            ServiceProducto service = new ServiceProducto();

            if (e.CommandName == "Editar")
            {
                Producto prod = service.buscarPorId(idProducto);

                ViewState["IdProductoEdit"] = prod.Id;

                if (prod != null)
                {
                    txtNombreEdit.Text = prod.Nombre;
                    txtStockActualEdit.Text = prod.StockActual.ToString();
                    txtPrecioCompraEdit.Text = prod.PrecioCompra.ToString();
                    txtPorcentajeGananciaEdit.Text = prod.Ganancia.ToString();

                    ddlMarcaEdit.SelectedValue = prod.Marca.Id.ToString();
                    ddlCategoriaEdit.SelectedValue = prod.Categoria.Id.ToString();

                    txtImagenUrlEdit.Text = prod.ImagenUrl;

                    panelEdit.Visible = true;
                }
                else
                {
                    lblMenssageStatus("Producto no encontrado.", "error");
                }

            }
            if (e.CommandName == "Eliminar")
            {
                ServiceProducto Service = new ServiceProducto();
                Service.eliminar(idProducto);

                lblMenssageStatus("Producto eliminado correctamente.", "error");

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
        protected void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto {
                Id = (int)ViewState["IdProductoEdit"],

                Nombre = txtNombreEdit.Text,
                StockActual = int.Parse(txtStockActualEdit.Text),
                PrecioCompra = float.Parse(txtPrecioCompraEdit.Text),
                Ganancia = float.Parse(txtPorcentajeGananciaEdit.Text),

                Marca = new Marca { Id = int.Parse(ddlMarcaEdit.SelectedValue) },
                Categoria = new Categoria { Id = int.Parse(ddlCategoriaEdit.SelectedValue) },

                ImagenUrl = txtImagenUrlEdit.Text,
                Activo = true,
            };

            ServiceProducto service = new ServiceProducto();
            service.modificar(prod);

            service.actualizarProveedorProducto(prod.Id, int.Parse(ddlProveedorEdit.SelectedValue));

            lblMenssageStatus("Producto modificado correctamente.");

            cargarGrid();

            panelEdit.Visible = false;
        }
        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
        }
    }
}