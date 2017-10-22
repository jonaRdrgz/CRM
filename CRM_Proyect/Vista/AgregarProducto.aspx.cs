using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.Services;

namespace CRM_Proyect
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        const int EXITO_DE_INSERCION = 0;
        private int FALLO_DE_INSERCION = -1;
        const int DATO_NO_NUMERICO = -7;
        Controlador controlador = Controlador.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string insertarProducto(string nombre, string descripcion, string precio)
        {
           
            Controlador controlador = Controlador.getInstance();

            if (controlador.agregarProducto(nombre, descripcion, precio) == EXITO_DE_INSERCION)
            {
              return "false";
            }
            return "true";

        }
        //public void insertarProducto(object sender, EventArgs e)
        //{


        //    string precio = Precio.Text;
        //    if (!isNumeric(precio))
        //    {
        //        string str33 = "El teléfono deben ser números";
        //        Response.Write("<script language=javascript>alert('" + str33 + "');</script>");
        //        Precio.Focus();
        //        return;
        //    }
        //    else
        //    {
        //            string nombre = Nombre.Text;
        //            string descripcion = Descripccion.Text;
        //            int resultadoControlador = controlador.agregarProducto(nombre, descripcion, precio);
        //            switch (resultadoControlador)
        //            {
        //                case DATO_NO_NUMERICO:
        //                    string telefonoNoNumerico = "El precio debe ser numérico";
        //                    Response.Write("<script language=javascript>alert('" + telefonoNoNumerico + "');</script>");
        //                    break;
        //                default:
        //                    string noOperacion = "No se puede realizar la operación";
        //                    Response.Write("<script language=javascript>alert('" + noOperacion + "');</script>");
        //                    break;
        //            }
        //    }
        //}

        //static bool isNumeric(string sValue)
        //{
        //    return Regex.IsMatch(sValue, "^[0-9]+$");
        //}

        //protected void agregarProducto(object sender, EventArgs e)
        //{
        //    string precio = Precio.Text;
        //    if (!isNumeric(precio))
        //    {
        //        string str33 = "El teléfono deben ser números";
        //        Response.Write("<script language=javascript>alert('" + str33 + "');</script>");
        //        Precio.Focus();
        //        return;
        //    }
        //    else
        //    {
        //        string nombre = Nombre.Text;
        //        string descripcion = Descripccion.Text;
        //        int resultadoControlador = controlador.agregarProducto(nombre, descripcion, precio);
        //        switch (resultadoControlador)
        //        {
        //            case DATO_NO_NUMERICO:
        //                string telefonoNoNumerico = "El precio debe ser numérico";
        //                Response.Write("<script language=javascript>alert('" + telefonoNoNumerico + "');</script>");
        //                break;
        //            default:
        //                string noOperacion = "No se puede realizar la operación";
        //                Response.Write("<script language=javascript>alert('" + noOperacion + "');</script>");
        //                break;
        //        }
        //    }
        //}
    }
}