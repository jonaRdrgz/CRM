/**
 *	 Interface IVenta
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

namespace CRM_Proyect.Modelo.ClassTest
{
    /**
    *	Interface que contiene los métodos necesarios para probar el manejo de ventas
    *
    */
    public interface IVenta
    {
        int crearVenta(String precio, String descuento, String comision, int idComprador);
        List<Venta> obtenerVentas();
        List<Producto> verProductosVenta(int idVenta);
    }
}
