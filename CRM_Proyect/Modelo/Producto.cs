using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CRM_Proyect.Modelo
{
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