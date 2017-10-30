/**
 *	Clase Controlador
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
	*	Clase para crear objetos venta cuando se hace la consulta en la base de datos.
	*
	*/
    public class Venta
    {
        public Venta(String productos, String fecha, String precio, String descuento, String comision,
            String vendedor ,String comprador,   String accion)
        {
            this.productos = productos;
            this.fecha = fecha;
            this.precio = precio;
            this.descuento = descuento;
            this.comision = comision;
            this.accion = accion;
            this.vendedor = vendedor;
            this.comprador = comprador;
        }

        public String productos { get; set; }
        public String fecha { get; set; }
        public String precio { get; set; }
        public String descuento { get; set; }
        public String comision { get; set; }
        public String vendedor { get; set; }
        public String comprador { get; set; }
        public String accion { get; set; }
    }
}