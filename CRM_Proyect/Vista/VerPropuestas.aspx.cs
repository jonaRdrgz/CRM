/**
 *	Clase VerPropuestas
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
    public partial class VerPropuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object obtenerPropuestasDeVenta()
        {
            Controlador controlador = Controlador.getInstance();
            List<PropuestasVenta> propuestas = controlador.obtenerPropuestasVenta();
            object json = new { data = propuestas };
            return json;
        }

        [WebMethod]
        public static object verProductosPropuesta(int idPropuesta)
        {

            Controlador controlador = Controlador.getInstance();
            List<Producto> productos = controlador.verProductosPropuesta(idPropuesta);
            object json = new { data = productos };
            return json;
        }

        [WebMethod]
        public static object verComentariosPropuesta(int idPropuesta)
        {

            Controlador controlador = Controlador.getInstance();
            List<Comentario> comentarios = controlador.verComentariosPropuesta(idPropuesta);
            object json = new { data = comentarios };
            return json;
        }

        [WebMethod]
        public static string cambiarRespuesta(int idPropuesta, string respuesta)
        {

            Controlador controlador = Controlador.getInstance();
            if (respuesta.Equals("")) {
                return "La respuesta no puede ser vacía ";
            }
            if (controlador.cambiarRespuesta(idPropuesta, respuesta))
            {
                return "Se cambió con éxito";
            }
            return "No se realizó la operación";
        }

    }
}