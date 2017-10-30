/**
 *	Clase Producto
 *	
 *	Version 1.0
 *	
 *	21/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;

namespace CRM_Proyect.Modelo
{
	/**
	*	Clase para crear objetos producto cuando se hace la consulta en la base de datos.
	*/
    public class Producto
    {
        public Producto(String nombre, String descripcion, String precio, String accion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.accion = accion;
        }

        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String precio { get; set; }
        public String accion { get; set; }



    }
}