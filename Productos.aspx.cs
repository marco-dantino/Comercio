using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                var productos = new List<dynamic>
                {
                    new {Imagen = "https://res.cloudinary.com/dnpxdmyhl/image/upload/v1750361574/bc_PineappleIce_trgsnn.webp", Id = 1, Nombre = "Monitor", stock_actual = 10, precio_unitario = 250000, ganancia = 20, Marca = "Samsung", Categoria = "Periféricos" },
                    new {Imagen = "https://res.cloudinary.com/dnpxdmyhl/image/upload/v1745361787/Elfbar_Bc_20000_zl7zp7.webp", Id = 2, Nombre = "Teclado", stock_actual = 40, precio_unitario = 8000, ganancia = 15, Marca = "Logitech", Categoria = "Periféricos" },
                    new {Imagen = "https://res.cloudinary.com/dnpxdmyhl/image/upload/v1745361787/Elfbar_Bc_20000_zl7zp7.webp", Id = 3, Nombre = "Teclado", stock_actual = 40, precio_unitario = 8000, ganancia = 15, Marca = "Logitech", Categoria = "Periféricos" },
                    new {Imagen = "https://res.cloudinary.com/dnpxdmyhl/image/upload/v1745361787/Elfbar_Bc_20000_zl7zp7.webp", Id = 4, Nombre = "Teclado", stock_actual = 40, precio_unitario = 8000, ganancia = 15, Marca = "Logitech", Categoria = "Periféricos" },
                    new {Imagen = "https://res.cloudinary.com/dnpxdmyhl/image/upload/v1745361787/Elfbar_Bc_20000_zl7zp7.webp", Id = 5, Nombre = "Teclado", stock_actual = 40, precio_unitario = 8000, ganancia = 15, Marca = "Logitech", Categoria = "Periféricos" },
                    new {Imagen = "https://res.cloudinary.com/dnpxdmyhl/image/upload/v1745361787/Elfbar_Bc_20000_zl7zp7.webp", Id = 6, Nombre = "Teclado", stock_actual = 40, precio_unitario = 8000, ganancia = 15, Marca = "Logitech", Categoria = "Periféricos" },
                    new {Imagen = "https://res.cloudinary.com/dnpxdmyhl/image/upload/v1745361787/Elfbar_Bc_20000_zl7zp7.webp", Id = 7, Nombre = "Teclado", stock_actual = 40, precio_unitario = 8000, ganancia = 15, Marca = "Logitech", Categoria = "Periféricos" },
                    new {Imagen = "https://res.cloudinary.com/dnpxdmyhl/image/upload/v1745361787/Elfbar_Bc_20000_zl7zp7.webp", Id = 8, Nombre = "Teclado", stock_actual = 40, precio_unitario = 8000, ganancia = 15, Marca = "Logitech", Categoria = "Periféricos" }
                };

                gvProductos.DataSource = productos;
                gvProductos.DataBind();
            }
        }
    }
}