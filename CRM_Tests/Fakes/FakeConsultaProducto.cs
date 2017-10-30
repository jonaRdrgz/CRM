/**
 *	Clase FakeConsultaProducto
 *	
 *	Version 1.0
 *	
 *	26/10/2017
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
    class FakeConsultaProducto:IConsultaProducto
    {
        public Boolean debeResponder = false;
        public int resultadoExitoso = 0;
        List<Producto> lista = new List<Producto>();
        public int agregarProducto(String nombre, String descripcion, String precio) {
            return resultadoExitoso;
        }

        public List<Producto> obtenerProductos() {
            return lista;
        }
        public Boolean borrarProducto(int idProducto) {
            return debeResponder;
        }

        public List<Producto> obtenerProductosDisponibles() {
            return lista;
        }

        public Boolean agregarAlCarrito(int idProducto) {
            return debeResponder;
        }
        public List<Producto> obtenerProductosCarrito() {
            return lista;
        }
        public Boolean eliminarDelCarrito(int idProducto) {
            return debeResponder;
        }

    }
}
