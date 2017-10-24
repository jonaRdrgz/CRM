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
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM_Proyect.Modelo
{
    public class PropuestasVenta
    {
        public PropuestasVenta(String productos, String precio, String descuento, String comision,
                String comentarios,  String accion)
        {
            this.productos = productos;
            this.precio = precio;
            this.descuento = descuento;
            this.comision = comision;
            this.comentarios = comentarios;
            this.accion = accion;
        }
        public String productos { get; set; }
        public String precio { get; set; }
        public String descuento { get; set; }
        public String comision { get; set; }
        public String comentarios { get; set; }
        public String accion { get; set; }
    }
}