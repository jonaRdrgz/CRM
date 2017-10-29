/**
 *	Clase EliminarProducto
 *	
 *	Version 1.0
 *	
 *	24/09/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

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
    public partial class EliminarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static object mostrarProductos()
        {
            Controlador controlador = Controlador.getInstance();
            List<Producto> productos = controlador.obtenerProductos();
            object json = new { data = productos };

            return json;
        }
        [WebMethod]
        public static string borrarProducto(int idProducto)
        {

            Controlador controlador = Controlador.getInstance();

            if (controlador.borrarProducto(idProducto))
            {
                return "true";
            }
            return "false";
        }

    }
}