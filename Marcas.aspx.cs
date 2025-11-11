using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    var marcas = new List<dynamic>
            //    {
            //        new { Id = 1, Nombre = "Addidas" },
            //        new { Id = 2, Nombre = "nike" },
            //        new { Id = 3, Nombre = "Marca nose que" }
            //    };

            //    gvMarcas.DataSource = marcas;
            //    gvMarcas.DataBind();
            //}
            
                gvMarcas.DataSource = new List<Marcas>();
                gvMarcas.DataBind();
        }
    }
}