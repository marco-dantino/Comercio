using ComercioDomain;
using ComercioDomain.Sales;
using ComercioService;
using ComercioService.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Facturacion : PageWithAuth
    {
        protected string JsonDetalles = "[]";
        protected void Page_Load(object sender, EventArgs e)
        {
            string numero = Request.QueryString["factura"];

            if (!string.IsNullOrEmpty(numero))
            {
                ServiceVenta service = new ServiceVenta();
                var lista = service.ListarPorNumeroFactura(numero);

                JsonDetalles = JsonConvert.SerializeObject(lista);

                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "generarPDF",
                    "generarPDF();",
                    true
                );
            }

            if (!IsPostBack)
            {
                cargarGrid();
            }
        }
        private void cargarGrid()
        {
            ServiceVenta Service = new ServiceVenta();
            gvFacturas.DataSource = Service.listarPorUsuario((Usuario)Session["usuario"]);
            gvFacturas.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ServiceVenta Service = new ServiceVenta();
            Usuario idUsuarioLogueado = (Usuario)Session["usuario"];

            if (txtFechaDesde.Text == "" || txtFechaHasta.Text == "")   return;
            
            DateTime fechaDesde = DateTime.Parse(txtFechaDesde.Text);
            DateTime fechaHasta = DateTime.Parse(txtFechaHasta.Text);

            gvFacturas.DataSource = Service.listarPorRango(idUsuarioLogueado.Id, fechaDesde, fechaHasta);
            gvFacturas.DataBind();
        }
        protected void btnListar_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
        protected void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            ServiceVenta Service = new ServiceVenta();
            Usuario UsuarioLogueado = (Usuario)Session["usuario"];

            string textoBusqueda = txtFactura.Text.Trim();

            List<Venta> ventasFiltradas = !string.IsNullOrEmpty(textoBusqueda) ? Service.listarPorFactura(UsuarioLogueado.Id, textoBusqueda) : Service.listarPorUsuario(UsuarioLogueado);

            gvFacturas.DataSource = ventasFiltradas;
            gvFacturas.DataBind();
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

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            string numFactura = btn.CommandArgument;
            Response.Redirect("Facturacion.aspx?factura=" + numFactura);
        }
    }
}