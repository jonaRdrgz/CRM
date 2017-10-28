/**
 *	Clase ValidadorProductos
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
using CRM_Proyect.Modelo.ClassTest;
using CRM_Proyect.Modelo;

namespace CRM_Tests
{
    class ValidadorProductos
    {
        private IConsultaProducto manager;

        public ValidadorProductos(IConsultaProducto mgr)
        {
            manager = mgr;
        }

        public int agregarProducto(String nombre, String descripcion, String precio)
        {
            return manager.agregarProducto(nombre, descripcion, precio);
        }
        public List<Producto> obtenerProductos() {
            return manager.obtenerProductos();
        }

        public Boolean borrarProducto(int idProducto) {
            return manager.borrarProducto(idProducto);
        }
        public List<Producto> obtenerProductosDisponibles() {
            return manager.obtenerProductosDisponibles();
        }
        public Boolean agregarAlCarrito(int idProducto) {
            return manager.agregarAlCarrito(idProducto);
        }
        public List<Producto> obtenerProductosCarrito() {
            return manager.obtenerProductosCarrito();
        }
        public Boolean eliminarDelCarrito(int idProducto) {
            return manager.eliminarDelCarrito(idProducto);
        }
    }
}
