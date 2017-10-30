/**
 *	Clase FakeVenta
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
using System.Collections.Generic;
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
