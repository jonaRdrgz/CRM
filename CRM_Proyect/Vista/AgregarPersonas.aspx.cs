/**
 *	Clase AgregarPersonas
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
using System.Windows.Forms;

namespace CRM_Proyect
{
    public partial class AgregarPersonas : System.Web.UI.Page
    {
        Controlador controlador = Controlador.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void Page_PreInit(Object sender, EventArgs e)
        {

            if (!controlador.getSession())
            {
                Response.Redirect("/Vista/pages/examples/login.aspx");
            }
        }

        [WebMethod]
        public static object obtenerPersonas()
        {
            Controlador controlador = Controlador.getInstance();
            List<Usuario> personas = controlador.obtenerPersonas();
            object json = new { data = personas };
            return json;
        }

        [WebMethod]
        public static string agregarContacto(int user)
        {
            Controlador controlador = Controlador.getInstance();

            if (controlador.registarContactoPersona(user))
            {
                return "true";
            }
            return "false";
        }
    }

}