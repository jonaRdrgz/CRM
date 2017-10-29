/**
 *	Clase CrearVenta
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
        public static string crearVenta(string precio, string descuento, string comision, int idComprador)
        {

            Controlador controlador = Controlador.getInstance();
            return controlador.crearVenta(precio, descuento, comision, idComprador);
        }

        public void obtenerEmpresas() {
            String options = "";
            Controlador controlador = Controlador.getInstance();
            List<Empresa> empresas = controlador.obtenerContactoEmpresas();

            foreach (Empresa empresa in empresas) {
                options += "<option value=" + empresa.id + ">" + empresa.nombre + "</option>";
            }

            Response.Write( options);
        }
    }
    
}