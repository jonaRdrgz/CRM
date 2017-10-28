/**
 *	Interface IPropuestaVenta
 *	
 *	Version 1.0
 *	
 *	24/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Proyect.Modelo.ClassTest
{
    public interface IPropuestaVenta
    {
        int crearPropuestaVenta(String precio, String descuento, String comision, int idComprador);
        int insertarProductoAPropuesta(int idPropuesta);
        Boolean verificarNumeroProductosCarrito();
        List<PropuestasVenta> obtenerPropuestasVenta();
        List<Producto> verProductosPropuesta(int idPropuesta);
        List<PropuestasVenta> obtenerPropuestasVentaCompra();
        List<PropuestasVenta> obtenerPropuestasDeVentaUsuario();
        Boolean comentarPropuesta(int idPropuesta, string comentario);
        Boolean cambiarRespuesta(int idPropuesta, string respuesta);
    }
}
