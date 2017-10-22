using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Proyect
{
    public partial class PropuestaDeVentas : System.Web.UI.Page
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

    }
}