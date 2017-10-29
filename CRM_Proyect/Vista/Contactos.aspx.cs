/**
 *	Clase Contactos
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

namespace CRM_Proyect
{
    public partial class Contactos : System.Web.UI.Page
    {
        Controlador controlador = Controlador.getInstance();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void Page_PreInit(Object sender, EventArgs e)
        {

            if (!controlador.getSession())
            {
                Response.Redirect("/pages/examples/login.aspx");
            }
        }

        [WebMethod]
        public static  object obtenerUsuarios()
        {
            Controlador controlador = Controlador.getInstance();
            List<Usuario> usuarios = controlador.obtenerContactoPersonas();
            object json = new { data = usuarios };

            return json;
        }


        [WebMethod]
        public static string borrarContacto(int user)
        {
            Controlador controlador = Controlador.getInstance();

            if (controlador.borrarContacto(user))
            {
                return "true";
            }
            return "false";

        }

    }
}