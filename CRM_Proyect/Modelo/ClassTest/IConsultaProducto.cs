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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Proyect.Modelo.ClassTest
{
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
