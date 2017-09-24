using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;
using System.Web.Mvc;


namespace CRM_Proyect
{
    
    public partial class login : System.Web.UI.Page
    {
        Controlador controlador = new Controlador();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public String DoWork(String correo, String contrasena)
        {

            return "jdshdsjfh";
        }

        protected void ingresarUsuario(object sender, EventArgs e)
        {
            string n = controlador.getUser();

            Response.Write("<script>alert('"+n+"');</script>");

            if (Page.IsValid)
            {
                
                //Response.Redirect("../../index.aspx");
            }

        }
    }
}