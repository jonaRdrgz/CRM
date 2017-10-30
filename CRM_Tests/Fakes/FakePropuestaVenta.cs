/**
 *	Clase FakePropuestaVenta
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_Proyect.Modelo.ClassTest;
using CRM_Proyect.Modelo;

namespace CRM_Tests.Fakes
{
    class FakePropuestaVenta: IPropuestaVenta
    {
        public int exitoRetorno = 0;
        public Boolean exitoConsulta = true;
        public List<PropuestasVenta> listaVenta = new List<PropuestasVenta>();
        public List<Producto> listaProducto = new List<Producto>();

        public int crearPropuestaVenta(String precio, String descuento, String comision, int idComprador) {
            return exitoRetorno;
        }
        public int insertarProductoAPropuesta(int idPropuesta) {
            return exitoRetorno;
        }

        public Boolean verificarNumeroProductosCarrito() {
            return exitoConsulta;
        }
        public List<PropuestasVenta> obtenerPropuestasVenta() {
            return listaVenta;
        }

        public List<Producto> verProductosPropuesta(int idPropuesta) {
            return listaProducto;
        }

        public List<PropuestasVenta> obtenerPropuestasVentaCompra() {
            return listaVenta;
        }
        public List<PropuestasVenta> obtenerPropuestasDeVentaUsuario() {
            return listaVenta;
        }

        public Boolean comentarPropuesta(int idPropuesta, string comentario) {
            return exitoConsulta;
        }
        public Boolean cambiarRespuesta(int idPropuesta, string respuesta) {
            return exitoConsulta;
        }
    }
}
