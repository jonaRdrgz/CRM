/**
 *	Clase ValidadorVenta
 *	
 *	Version 1.0
 *	
 *	24/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;
using CRM_Proyect.Modelo.ClassTest;
using CRM_Proyect.Modelo;

namespace CRM_Tests
{
    /**
    *	Clase para validar las ventas en el sistema.
    *
    */
    class ValidadorVenta
    {
        private IVenta manager;

        public ValidadorVenta(IVenta mgr)
        {
            manager = mgr;
        }

        public int crearVenta(String precio, String descuento, String comision, int idComprador)
        {
            return manager.crearVenta(precio, descuento, comision, idComprador);
        }
        public List<Venta> obtenerVentas() {
            return manager.obtenerVentas();
        }

        public List<Producto> verProductosVenta(int idVenta) {
            return manager.verProductosVenta(idVenta);
        }
    }
}
