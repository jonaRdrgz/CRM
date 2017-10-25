using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using CRM_Proyect.Modelo;

namespace CRM_Proyect
{
    public partial class VerVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static object obtenerVentas()
        {
            Controlador controlador = Controlador.getInstance();
            List<Venta> ventas = controlador.obtenerVentas();
            object json = new { data = ventas };
            return json;
        }

        [WebMethod]
        public static object verProductosVenta(int idVenta)
        {

            Controlador controlador = Controlador.getInstance();
            List<Producto> productos = controlador.verProductosVenta(idVenta);
            object json = new { data = productos };
            return json;
        }
    }
}