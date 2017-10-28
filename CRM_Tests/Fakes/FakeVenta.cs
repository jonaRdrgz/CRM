using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_Proyect.Modelo.ClassTest;
using CRM_Proyect.Modelo;

namespace CRM_Tests.Fakes
{
    class FakeVenta:IVenta
    {
        public int exitoRetorno = 0;
        public Boolean exitoConsulta = true;
        public List<Venta> listaVenta = new List<Venta>();
        public List<Producto> listaProducto = new List<Producto>();

        public int crearVenta(String precio, String descuento, String comision, int idComprador) {
            return exitoRetorno;
        }

        public List<Venta> obtenerVentas() {
            return listaVenta;
        }

        public List<Producto> verProductosVenta(int idVenta) {
            return listaProducto;
        }
    }
}
