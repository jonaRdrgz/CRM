/**
 *	Clase CrearVenta
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
    public partial class CrearVenta : System.Web.UI.Page
    {

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
        public static string crearPropuesta(string precio, string descuento, string comision, int idComprador)
        {
            Controlador controlador = Controlador.getInstance();
            return controlador.crearPropuestaVenta(precio, descuento, comision, idComprador);

        }
        public void obtenerEmpresas()
        {
            String options = "";
            Controlador controlador = Controlador.getInstance();
            List<Empresa> empresas = controlador.obtenerContactoEmpresas();

            foreach (Empresa empresa in empresas)
            {
                options += "<option value=" + empresa.id + ">" + empresa.nombre + "</option>";
            }

            Response.Write(options);
        }

    }
}