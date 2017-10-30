/**
 *	Clase ValidadorPropuestaVenta
 *	
 *	Version 1.0
 *	
 *	27/10/2017
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
    *	Clase para validar las propuestas de venta ingresadas en el sistema.
    *
    */

    class ValidadorPropuestaVenta
    {
        private IPropuestaVenta manager;

        public ValidadorPropuestaVenta(IPropuestaVenta mgr)
        {
            manager = mgr;
        }

        public int crearPropuestaVenta(String precio, String descuento, String comision, int idComprador) {
            return manager.crearPropuestaVenta(precio, descuento, comision, idComprador);
        }
        public int insertarProductoAPropuesta(int idPropuesta) {
            return manager.insertarProductoAPropuesta(idPropuesta);
        }
        public Boolean verificarNumeroProductosCarrito() {
            return manager.verificarNumeroProductosCarrito();
        }

        public List<PropuestasVenta> obtenerPropuestasVenta() {
            return manager.obtenerPropuestasVenta();
        }
        public List<Producto> verProductosPropuesta(int idPropuesta) {
            return manager.verProductosPropuesta(idPropuesta);
        }

        public List<PropuestasVenta> obtenerPropuestasVentaCompra() {
            return manager.obtenerPropuestasVentaCompra();
        }

        public List<PropuestasVenta> obtenerPropuestasDeVentaUsuario() {
            return manager.obtenerPropuestasDeVentaUsuario();
        }
        public Boolean comentarPropuesta(int idPropuesta, string comentario)
        {
            return manager.comentarPropuesta(idPropuesta, comentario);
        }
        public Boolean cambiarRespuesta(int idPropuesta, string respuesta)
        {
            return manager.cambiarRespuesta(idPropuesta, respuesta);
        }
    }
}
