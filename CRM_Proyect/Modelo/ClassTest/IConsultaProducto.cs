/**
 *	Interface IConsultaProducto
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


namespace CRM_Proyect.Modelo.ClassTest
{
    /**
    *	Interface que contiene los métodos necesarios para probar el manejo de productos.
    *
    */
    public interface IConsultaProducto
    {
         int agregarProducto(String nombre, String descripcion, String precio);
        List<Producto> obtenerProductos();
        Boolean borrarProducto(int idProducto);
        List<Producto> obtenerProductosDisponibles();
        Boolean agregarAlCarrito(int idProducto);
        List<Producto> obtenerProductosCarrito();
        Boolean eliminarDelCarrito(int idProducto);
    }
}
