/**
 *	Interface IConexion
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
using System.Data;

namespace CRM_Proyect.Modelo.ClassTest
{
    /**
    *	Interface que contiene los métodos necesarios para probar la conexión a la base de datos.
    *
    */
    interface IConexion
    {
        Boolean abrirConexion();
        Boolean cerrarConexion();
        Boolean command(String comando);
        IDataReader obtenerResultados();
    }
}
