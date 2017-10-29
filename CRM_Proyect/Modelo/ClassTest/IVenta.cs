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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Proyect.Modelo.ClassTest
{
    public interface IVenta
    {
        int crearVenta(String precio, String descuento, String comision, int idComprador);
        List<Venta> obtenerVentas();
        List<Producto> verProductosVenta(int idVenta);
    }
}
