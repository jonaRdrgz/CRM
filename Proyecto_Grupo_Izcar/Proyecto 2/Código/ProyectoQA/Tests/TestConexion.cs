using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestConexion
    {
        [TestCase]
        public void AbrirConexion_CredencialesInvalidas_ReturnFalse()
        {
            Conexion conexion = new Conexion("", "", "", "", "");
            Assert.AreEqual(false, conexion.AbrirConexion());
        }
        [TestCase]
        public void AbrirConexion_CredencialesValidas_ReturnTrue()
        {
            Conexion conexion = new Conexion("localhost", "mydb", "root", "root", "3306");
            Assert.AreEqual(true, conexion.AbrirConexion());
        }
        [TestCase]
        public void AbrirConexion_CredencialesValidas_OpenState()
        {
            Conexion conexion =   new Conexion("localhost", "mydb", "root", "root", "3306");
            conexion.AbrirConexion();
            Assert.AreEqual(ConnectionState.Open, conexion.getConexion().State);
        }
        [TestCase]
        public void CerrarConexion_CredencialesValidas_CloseState()
        {
            Conexion conexion = new   Conexion("localhost", "mydb", "root", "root", "3306");
            conexion.AbrirConexion();
            conexion.CerrarConexion();
            Assert.AreNotEqual(ConnectionState.Open, conexion.getConexion().State);
        }
        [TestCase]
        public void setCommandText_QueryValido_ReturnTrue()
        {
            Conexion conexion = new   Conexion("localhost", "mydb", "root", "root", "3306");
            conexion.AbrirConexion();
            Assert.AreEqual(true, conexion.setCommandText("call getUsuario('hola');"));
        }
        [TestCase]
        public void getResultados_ConexionInvalida_ThrowsException()
        {
            Conexion conexion = new Conexion("", "", "", "", "");
            conexion.AbrirConexion();
            conexion.setCommandText("call getUsuario('hola');");
            Assert.Catch<InvalidOperationException>(() => conexion.getResultados());
        }
        [TestCase]
        public void getResultados_ConexionValida_ThrowsException()
        {
            Conexion conexion =   new Conexion("localhost", "mydb", "root", "root", "3306");
            conexion.AbrirConexion();
            conexion.setCommandText("call getUsuario('jonastu.9@gmail.com');");
            Assert.AreEqual(true, conexion.getResultados().Read());
        }
    }
}