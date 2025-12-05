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
    public partial class Facturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }
        private void cargarGrid()
        {
            ServiceVenta service = new ServiceVenta();
            gvFacturas.DataSource = service.listarPorUsuario((Usuario)Session["usuario"]);
            gvFacturas.DataBind();
        }
    }
}