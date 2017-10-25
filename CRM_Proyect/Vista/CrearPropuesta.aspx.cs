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
    public partial class CrearVenta : System.Web.UI.Page
    {
        const int PRODUCTOS_INSUFICIENTES = -2;
        const int EXITO_DE_INSERCION = 0;
        const int FALLO_DE_INSERCION = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object mostrarProductosDisponibles()
        {
            Controlador controlador = Controlador.getInstance();
            List<Producto> productos = controlador.obtenerProductosDisponibles();
            object json = new { data = productos };

            return json;
        }

        [WebMethod]
        public static string agregarAlCarrito(int idProducto)
        {

            Controlador controlador = Controlador.getInstance();

            if (controlador.agregarAlCarrito(idProducto))
            {
                return "true";
            }
            return "false";
        }

        [WebMethod]
        public static object mostrarProductosCarrito()
        {
            Controlador controlador = Controlador.getInstance();
            List<Producto> productos = controlador.obtenerProductosCarrito();
            object json = new { data = productos };

            return json;
        }

        [WebMethod]
        public static string eliminarDelCarrito(int idProducto)
        {

            Controlador controlador = Controlador.getInstance();

            if (controlador.eliminarDelCarrito(idProducto))
            {
                return "true";
            }
            return "false";
        }

        [WebMethod]
        public static string crearPropuesta(string precio, string descuento, string comision )
        {

            Controlador controlador = Controlador.getInstance();
            int respuestaControlador = controlador.crearPropuestaVenta(precio, descuento, comision);
            switch (respuestaControlador) {
                case PRODUCTOS_INSUFICIENTES:               
                    return "Producto Insu";

                case FALLO_DE_INSERCION:
                    return "false";
                default:

                   return "true";

            }
        }

    }
}