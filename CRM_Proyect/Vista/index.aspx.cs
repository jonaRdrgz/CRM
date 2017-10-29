/**
 *	Clase Index, contenido principal
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
    public partial class WebForm1 : System.Web.UI.Page
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
        public static void cerrarSession()
        {
            Controlador controlador = Controlador.getInstance();
            controlador.setSessionFalse();
            return;        
        }
    }
}