/**
 *	Clase PropuestasVenta
 *	
 *	Version 1.0
 *	
 *	22/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;

namespace CRM_Proyect.Modelo
{
    /**
	*	Clase para crear objetos PropuestaVenta cuando se hace la consulta en la base de datos.
	*
	*/
    public class PropuestasVenta
    {
    	
        public PropuestasVenta(String productos, String precio, String descuento, String comision, String fecha, String respuesta,
            String comprador,  String comentarios,  String accion)
        {
            this.productos = productos;
            this.precio = precio;
            this.descuento = descuento;
            this.comision = comision;
            this.fecha = fecha;
            this.respuesta = respuesta;
            this.comprador = comprador;
            this.comentarios = comentarios;
            this.accion = accion;
        }
        public String productos { get; set; }
        public String precio { get; set; }
        public String descuento { get; set; }
        public String comision { get; set; }
        public String fecha{ get; set; }
        public String respuesta { get; set; }
        public String comprador { get; set; }
        public String comentarios { get; set; }
        public String accion { get; set; }
    }
}