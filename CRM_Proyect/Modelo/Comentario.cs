/**
 *	Clase Comentario
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
	*	Clase para crear objetos Comentarios cuando se hace la consulta en la base de datos.
	*
	*/
    public class Comentario
    {
        public Comentario(String nombre, String apellidoUno, String apellidoDos, String comentario)
        {
            this.nombre = nombre;
            this.apellidoUno = apellidoUno;
            this.apellidoDos = apellidoDos;
            this.comentario = comentario;
        }

        public String nombre { get; set; }
        public String apellidoUno { get; set; }
        public String apellidoDos { get; set; }
        public String comentario { get; set; }
    }
}