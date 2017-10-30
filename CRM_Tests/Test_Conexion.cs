/**
 *	Clase Test_Conexion
 *	
 *	Version 1.0
 *	
 *	27/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using NUnit.Framework;
using System;
using CRM_Proyect.Modelo;

namespace CRM_Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas de la conexión a la base de datos.
    *
    */
    class Test_Conexion
    {
        [TestCase]
        public void AbrirConexion_CredencialesInvalidas_ReturnFalse()
        {
            Conexion conexion = new Conexion("", "", "", "", "");
            Assert.AreEqual(false, conexion.abrirConexion());
        }
        [TestCase]
        public void AbrirConexion_CredencialesValidas_ReturnTrue()
        {
            Conexion conexion = new Conexion("localhost", "crm", "root", "root", "3306");
            Assert.AreEqual(true, conexion.abrirConexion());
        }
        [TestCase]
        public void AbrirConexion_CredencialesValidas_OpenState()
        {
            Conexion conexion = new Conexion("localhost", "crm", "root", "root", "3306");
            Boolean result = conexion.abrirConexion();
            Assert.AreEqual(true, result);
        }
        [TestCase]
        public void CerrarConexion_CredencialesValidas_CloseState()
        {
            Conexion conexion = new Conexion("localhost", "mydb", "root", "", "3306");
            conexion.abrirConexion();
            Boolean result = conexion.cerrarConexion();
            Assert.AreEqual(true, result);
        }
    }
}
