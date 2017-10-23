using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM_Proyect.Modelo
{
    public class Venta
    {
        public Venta(String productos, String fecha, String precio, String descuento, String comision,
            String vendedor ,  String accion)
        {
            this.productos = productos;
            this.fecha = fecha;
            this.precio = precio;
            this.descuento = descuento;
            this.comision = comision;
            this.accion = accion;
            this.vendedor = vendedor;
        }
        public String productos { get; set; }
        public String fecha { get; set; }
        public String precio { get; set; }
        public String descuento { get; set; }
        public String comision { get; set; }
        public String vendedor { get; set; }
        public String accion { get; set; }
    }
}