/**
 *	Clase Compras
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
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static object obtenerPropuestasDeVenta()
        {
            Controlador controlador = Controlador.getInstance();
            List<PropuestasVenta> propuestas = controlador.obtenerPropuestasVentaCompra();
            object json = new { data = propuestas };
            return json;
        }

        [WebMethod]
        public static string comprar(int idPropuesta)
        {

            Controlador controlador = Controlador.getInstance();

            if (controlador.comprar(idPropuesta))
            {
                return "true";
            }
            return "false";
        }
    }
}