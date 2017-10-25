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
    public partial class CrearVenta1 : System.Web.UI.Page
    {
        const int PRODUCTOS_INSUFICIENTES = -2;
        const int EXITO_DE_INSERCION = 0;
        const int FALLO_DE_INSERCION = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string crearVenta(string precio, string descuento, string comision)
        {

            Controlador controlador = Controlador.getInstance();
            int respuestaControlador = controlador.crearVenta(precio, descuento, comision);
            switch (respuestaControlador)
            {
                case PRODUCTOS_INSUFICIENTES:
                    return "Producto Insuficientes";

                case FALLO_DE_INSERCION:
                    return "false";
                default:

                    return "true";

            }
        }
    }
    
}