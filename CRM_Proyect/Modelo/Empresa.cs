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
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM_Proyect.Modelo
{
    public class Empresa
    {
        public Empresa(String nombre, String direccion,
                String correo, String telefono, String accion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.correo = correo;
            this.telefono = telefono;
            this.accion = accion;
        }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public String correo { get; set; }
        public String telefono { get; set; }
        public String accion { get; set; }
    }
}