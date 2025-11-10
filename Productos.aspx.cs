using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var productos = new List<dynamic>
                {
                    new { Id = 1, Nombre = "Monitor", stock_actual = 10, precio_unitario = 250000, ganancia = 20, Marca = "Samsung", Categoria = "Periféricos" },
                    new { Id = 2, Nombre = "Teclado", stock_actual = 40, precio_unitario = 8000, ganancia = 15, Marca = "Logitech", Categoria = "Periféricos" }
                };

                gvProductos.DataSource = productos;
                gvProductos.DataBind();
            }
        }
    }
}