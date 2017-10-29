/**
 *	Clase InfoEmpresas
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
using CRM_Proyect.Modelo;
using System.Web.Services;
using System.Windows.Forms;
using System.Web.SessionState;

namespace CRM_Proyect
{
    public partial class InfoEmpresas : System.Web.UI.Page
    {
        Controlador controlador = Controlador.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        void Page_PreInit(Object sender, EventArgs e)
        {
            
            if (!controlador.getSession()) {
                Response.Redirect("/Vista/pages/examples/login.aspx");
            }
        }

        [WebMethod]
        public static object obtenerEmpresas()
        {
            Controlador controlador = Controlador.getInstance();
            List<Empresa> empresas = controlador.obtenerContactoEmpresas();
            object json = new { data = empresas };

            return json;
        }

        [WebMethod]
        public static string borrarContactoEmpresa(int idEmpresa)
        {
            Controlador controlador = Controlador.getInstance();

            if (controlador.borrarContactoEmpresa(idEmpresa))
            {
                return "true";
            }
            return "false";

        }

    }
}