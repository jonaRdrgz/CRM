using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Proyect
{
    public partial class Site1 : System.Web.UI.MasterPage
    {   
        private int CUENTA_CLIENTE = 0;
        private int  CUENTA_EMPRESA = 1;
        Controlador controlador = Controlador.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        public void desplegarOpciones() {
            int tipoCuenta = controlador.getTipoCuenta() ;
            if (tipoCuenta == CUENTA_CLIENTE || tipoCuenta == CUENTA_EMPRESA)
            {
                imprimirOpcionesCliente();
            }
            else
            {
                imprimirOpcionesAdmin();
            }
        }
        private void imprimirOpcionesAdmin()
        {
            Response.Write(
                "<li class='treeview'>"
                + "<a href = '#' >"
                + "<i class='fa fa-fw fa-users'></i> <span>Contactos</span>"
                + "<span class='pull-right-container'>"
                + "<i class='fa fa-angle-left pull-right'></i>"
                + "</span>"
                + "</a>"
                + "<ul class='treeview-menu'>"
                + "<li><a href = 'Contactos.aspx' ><i class='fa fa-circle-o'></i> Personas</a></li>"
                + "<li><a href = 'InfoEmpresas.aspx'><i class='fa fa-circle-o'></i> Empresas</a></li>"
                + "<li><a href = 'AgregarPersonas.aspx'><i class='fa fa-circle-o'></i> Agregar Personas</a></li>"
                + "<li><a href = 'AgregarEmpresa.aspx'><i class='fa fa-circle-o'></i> Agregar Empresas</a></li>"
                + "</ul>"
                + "</li>"
                + "<li>"
                + "<li class='treeview'>"
                + "<a href = '#' >"
                + "<i class='fa fa-th'></i> <span>Productos</span>"
                + "<span class='pull-right-container'>"
                + "<i class='fa fa-angle-left pull-right'></i>"
                + "</span>"
                + "</a>"
                + "<ul class='treeview-menu'>"
                + "<li><a href = 'AgregarProducto.aspx' ><i class='fa fa-circle-o'></i> Agregar Producto</a></li>"
                + "<li><a href = 'EliminarProducto.aspx'><i class='fa fa-circle-o'></i> Eliminar Producto</a></li>"
                + "</ul>"
                + "</li>"
                + "<li>"
                + "<li class='treeview'>"
                + "<a href = '#' >"
                + "<i class='fa fa-check-square'></i> <span>Ventas</span>"
                + "<span class='pull-right-container'>"
                + "<i class='fa fa-angle-left pull-right'></i>"
                + "</span>"
                + "</a>"
                + "<ul class='treeview-menu'>"
                + "<li><a href = 'CrearVenta.aspx'><i class='fa fa-circle-o'></i>Crear Propuesta</a></li>"
                + "<li><a href = 'Contactos.aspx' ><i class='fa fa-circle-o'></i> Ver Propuestas</a></li>"
                + "<li><a href = 'InfoEmpresas.aspx'><i class='fa fa-circle-o'></i> Ver Ventas</a></li>"
                + "</ul>"
                + "</li>"
                );
        }

        private void imprimirOpcionesCliente() {
            Response.Write("<li>"
                   + " <a href='/Vista/PropuestaDeVentas.aspx'>"
                  + "<i class='fa-shopping-cart'></i> <span>Compras</span>"
                   + "</a>"
                   + "</li>"


                  + "<li>"
                  + " <a href='/Vista/PropuestaDeVentas.aspx'>"
                  + "<i class=' fa-commenting-o'></i> <span>Propuestas de ventas</span>"
                  + "</a>"
                  + "</li>");
        }
    }
}

    