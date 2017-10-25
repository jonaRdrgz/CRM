using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM_Proyect.Modelo
{
    public class PropuestasVenta
    {
        public PropuestasVenta(String productos, String precio, String descuento, String comision, String fecha, String respuesta,
                String comentarios,  String accion)
        {
            this.productos = productos;
            this.precio = precio;
            this.descuento = descuento;
            this.comision = comision;
            this.fecha = fecha;
            this.respuesta = respuesta;
            this.comentarios = comentarios;
            this.accion = accion;
        }
        public String productos { get; set; }
        public String precio { get; set; }
        public String descuento { get; set; }
        public String comision { get; set; }
        public String fecha{ get; set; }
        public String respuesta { get; set; }
        public String comentarios { get; set; }
        public String accion { get; set; }
    }
}