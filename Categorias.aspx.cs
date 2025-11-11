using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var categorias = new List<dynamic>
                {
                    new { Id = 1, Nombre = "Periféricos" },
                    new { Id = 2, Nombre = "Periféricos" }
                };
                
                gvCategorias.DataSource = categorias;
                gvCategorias.DataBind();
            }
        }
    }
}