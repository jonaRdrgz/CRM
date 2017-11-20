/**
 *	Clase TestRegistroCliente
 *	
 *	Version 1.0
 *	
 *	10/11/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoQA.Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas de registrar clientes
    *
    */
    public class TestRegistroCliente
    {
        [TestCase]
        public void verificarCorreoDuplicado_CorreoInvalido_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            Registro registro = new Registro(fakeConexion);
            Assert.AreEqual(false, (registro.verificarCorreoDuplicado("jefalva@gmail.com")));
        }

        [TestCase]
        public void verificarCorreoDuplicado_CorreoValido_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(true, (registro.verificarCorreoDuplicado("jefalva@gmail.com")));
        }

        [TestCase]
        public void verificarDatosUsuario_CorreoVacio_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(false, (registro.verificarDatosUsuario("", "123456", "123456")));
        }

        [TestCase]
        public void verificarDatosUsuario_CorreoInvalido_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(false, (registro.verificarDatosUsuario("jefalvagmail.com", "123456", "123456")));
        }
        [TestCase]
        public void verificarDatosUsuario_ContrasenaCorta_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(false, (registro.verificarDatosUsuario("jefalva@gmail.com", "1234", "1234")));
        }

        [TestCase]
        public void verificarDatosUsuario_ContrasenaLarga_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(false, (registro.verificarDatosUsuario("jefalva@gmail.com", "1234987898798139723787193798", "1234987898798139723787193798")));
        }
        [TestCase]
        public void verificarDatosUsuario_ContrasenaDistinta_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(false, (registro.verificarDatosUsuario("jefalva@gmail.com", "123498789878", "123498789879")));
        }
        [TestCase]
        public void verificarDatosUsuario_CorreoDuplicado_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(false, (registro.verificarDatosUsuario("UrielGomez@gmail.com", "123498789878", "123498789878")));
        }

        [TestCase]
        public void verificarDatosUsuario_DatosValidos_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(true, (registro.verificarDatosUsuario("jefalva@gmail.com", "123498789878", "123498789878")));
        }
        [TestCase]
        public void insertarUsuario_NoException_ReturnTrue()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(true, (registro.insertarUsuario("jefalva10296@gmail.com", "1029612")));
        }
        [TestCase]
        public void insertarUsuario_ThrowException_ReturnFalse()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true, true);
            RegistroCliente registro = new RegistroCliente(fakeConexion);
            Assert.AreEqual(false, (registro.insertarUsuario("jefalva10296@gmail.com", "1029612")));
        }
    }
}