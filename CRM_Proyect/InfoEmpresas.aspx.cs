using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRM_Proyect.Modelo;
using System.Web.Services;
using System.Windows.Forms;

namespace CRM_Proyect
{
    public partial class InfoEmpresas : System.Web.UI.Page
    {
        Controlador controlador = Controlador.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object obtenerEmpresas()
        {
            Controlador controlador = Controlador.getInstance();
            List<Empresa> empresas = controlador.obtenerContactoEmpresas();
            object json = new { data = empresas };

            return json;
        }

    }
}