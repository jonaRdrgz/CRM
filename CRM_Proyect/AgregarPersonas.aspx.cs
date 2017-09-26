﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {

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

            if (controlador.registarContacto(user))
            {
                return "true";
            }
            return "false";

        }
    }

}