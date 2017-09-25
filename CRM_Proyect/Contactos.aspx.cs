using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Proyect
{
    public partial class Contactos : System.Web.UI.Page
    {
        Controlador controlador = Controlador.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void obtenerPersonasContacto()
        {
            string contactoPeronas = controlador.obtenerContactoPersonas();
            Response.Write(contactoPeronas);
        }


    }
}