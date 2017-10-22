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
        Controlador controlador = Controlador.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ingresarUsuario(object sender, EventArgs e)
        {
            string str;
            if (Page.IsValid)
            {
                string usuario = TextBoxUsuario.Text;
                string contrasena = TextBoxContrasena.Text;
                
                if (controlador.validarUsuario(usuario, contrasena))
                {
                    //Response.Write("<script language=javascript>alert('" + idBoton + "');</script>");
                     Response.Redirect("../../index.aspx");
                }
                else {
                    str = "Usuario o contraseña incorrectos";
                    Response.Write("<script language=javascript>alert('" + str + "');</script>");
                    
                }
                

            }
        }
    }
}