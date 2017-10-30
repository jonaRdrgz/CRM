/**
 *	Clase Empresa
 *	
 *	Version 1.0
 *	
 *	25/09/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;

namespace CRM_Proyect.Modelo
{
	/**
	*	Clase para crear objetos Empresa cuando se hace la consulta en la base de datos.
	*
	*/
    public class Empresa
    {
        public Empresa(int id, String nombre, String direccion,
                String correo, String telefono, String accion)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.correo = correo;
            this.telefono = telefono;
            this.accion = accion;
        }
        public int id { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public String correo { get; set; }
        public String telefono { get; set; }
        public String accion { get; set; }
    }
}