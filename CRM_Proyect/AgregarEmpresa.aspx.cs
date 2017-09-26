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
    public partial class AgregarEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object mostrarEmpresas()
        {
            Controlador controlador = Controlador.getInstance();
            List<Empresa> empresas = controlador.obtenerEmpresas();
            object json = new { data = empresas };

            return json;
        }

        [WebMethod]
        public static string agregarEmpresa(int user)
        {
            Controlador controlador = Controlador.getInstance();

            if (controlador.registarContacto(user))
            {
                return "true";
            }
            return "false";

        }
    }
}