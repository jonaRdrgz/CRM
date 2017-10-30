/**
 *	Clase Tests_Manejo_Usuarios
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
using NUnit.Framework;
using CRM_Tests.Fakes;

namespace CRM_Tests
{
    [TestFixture]

    /**
    *	Clase para realizar pruebas para el manejo de usuarios que incluye ingreso de usuarios registrados
    *	y registro de usuarios y empresas en el sistema.
    *
    */
    class Tests_Manejo_Usuarios
    {

        private int Exito_De_Insercion = 0;
        private int Fallo_De_Insercion = -1;
        private int Contraseña_Muy_Corta = -2;
        private int Contraseña_Muy_Larga = -4;
        private int Usuario_Muy_Corto = -3;
        private int No_Contiene_Letras = -5;
        private int No_Contiene_Numeros = -6;
        private int Dato_No_Numerico = -7;
        private int Usuario_Muy_Largo = -8;
        private int Espacio_Vacio = -9;
      

        [Test]
        public void validarUsuario_UsuarioyContraseñaValidos_ReturnsTrue()
        {
            FakeConsulta instancia = new FakeConsulta();
            var resultado = instancia.validarUsuario("Admin", "1234567p");
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void validarUsuario_UsuarioValidoyContraseñaIncorrecta_ReturnsFalse()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.validarUsuario("Admin", "PassIncorrecta");
            Assert.AreEqual(resultado, false);

        }

        [Test]
        public void validarUsuario_UsuarioInvalidoyContraseñaCorrecta_ReturnsFalse()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.validarUsuario("Jona", "1234567p");
            Assert.AreEqual(resultado, false);

        }

        [Test]
        public void validarUsuario_CampoContraseñaEnBlanco_ReturnsFalse()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.validarUsuario("Admin", "");
            Assert.AreEqual(resultado, false);

        }

        [Test]
        public void validarUsuario_CampoUsuarioEnBlanco_ReturnsFalse()
        {
            var instancia = new FakeConsulta();
            var resultado = instancia.validarUsuario("", " 1234567p");
            Assert.AreEqual(resultado, false);

        }

        [Test]
        public void validarCorreo_VerificarCorreoExistente_ReturnsTrue()
        {
            FakeInsertarUsuario fakeManager = new FakeInsertarUsuario();
            fakeManager.debeResponder = true;
            ValidadorDatosUsuario correo = new ValidadorDatosUsuario(fakeManager);
            Boolean resultado = correo.validarCorreo("melimolinacorrales@gmail.com");
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void validarCorreo_VerificarCorreoNoExistente_ReturnsFalse()
        {
            FakeInsertarUsuario fakeManager = new FakeInsertarUsuario();
            fakeManager.debeResponder = false;
            ValidadorDatosUsuario correo = new ValidadorDatosUsuario(fakeManager);
            Boolean resultado = correo.validarCorreo("maria@gmail.com");
            Assert.AreEqual(resultado, false);

        }

        [Test]
        public void validarUsuario_VerificarUsuarioExistente_ReturnsTrue()
        {
            FakeInsertarUsuario fakeManager = new FakeInsertarUsuario();
            fakeManager.debeResponder = true;
            ValidadorDatosUsuario usuario = new ValidadorDatosUsuario(fakeManager);
            Boolean resultado = usuario.validarUsuario("Admin");
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void InsertarUsuarioBD_RegistrarUsuarioCorrecto_ReturnsExito_De_Insercion()
        {
            FakeInsertarUsuario fakeManager = new FakeInsertarUsuario();
            fakeManager.resultadoExitoso = 0;
            ValidadorDatosUsuario usuario = new ValidadorDatosUsuario(fakeManager);
            int  resultado = usuario.InsertarUsuarioBD("Carlos", "Gutierrez", "Rodríguez",
                "carlosgr@gmail.com", "San Rafael Abajo, Desamparados", "carlosgr", "carlosgr0508jt", "85167747");
            Assert.AreEqual(resultado, Exito_De_Insercion);
        }

        [Test]
        public void InsertarUsuarioBD_RegistrarUsuarioConUsuarioExistente_ReturnsFallo_De_Insercion()
        {

            FakeInsertarUsuario fakeManager = new FakeInsertarUsuario();
            fakeManager.resultadoExitoso = -1;
            ValidadorDatosUsuario usuario = new ValidadorDatosUsuario(fakeManager);
            int resultado = usuario.InsertarUsuarioBD("Carlos", "Gutierrez", "Rodríguez",
                "carlosgr@gmail.com", "San Rafael Abajo, Desamparados", "carlosgr", "carlosgr0508jt", "85167747");
            Assert.AreEqual(resultado, Fallo_De_Insercion);

        }


        [Test]
        public void insertarEmpresa_RegistrarEmpresaCorrecto_ReturnsExito_De_Insercion()
        {

            FakeInsertarUsuario fakeManager = new FakeInsertarUsuario();
            fakeManager.resultadoExitoso = 0;
            ValidadorDatosUsuario usuario = new ValidadorDatosUsuario(fakeManager);
            int resultado = usuario.insertarEmpresa("Samsung", "samsungcr@gmail.com", "Sabana Oeste", "22288929", 
                "samsungcr", "samsung2510");
            Assert.AreEqual(resultado, Exito_De_Insercion);

        }

        [Test]
        public void InsertarEmpresa_RegistrarEmpresaConNombreDeUsuarioExistente_ReturnsFallo_De_Insercion()
        {
            
            var instancia = new InsertarUsuario();
            FakeInsertarUsuario fakeManager = new FakeInsertarUsuario();
            fakeManager.resultadoExitoso = -1;
            ValidadorDatosUsuario usuario = new ValidadorDatosUsuario(fakeManager);
            int resultado = usuario.insertarEmpresa("Digitel", "digitelcr@gmail.com", "San Pedro", "22482879", 
                "intelcr", "samsung2510");
            Assert.AreEqual(resultado, Fallo_De_Insercion);

        }

        [Test]
        public void insertarUsuario_ContraseñaMuyCorta_ReturnsContraseña_Muy_Corta()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Gabriel", "Hernández", "Picado", "gabrielhp@gmail.com", "San Rafael Abajo, Desamparados", "gabo13hp", "gab13", "84167767");
            Assert.AreEqual(resultado, Contraseña_Muy_Corta);

        }

        [Test]
        public void insertarUsuario_ContraseñaMuyLarga_ReturnsContraseña_Muy_Larga()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Alejandra", "Carranza", "Chaves", "alecarranza04@gmail.com", "San Antonio,Escazú", "ale56cc", "Esta_es_una_contraseña_muy_larga_para_pruebas_solamente", "85169767");
            Assert.AreEqual(resultado, Contraseña_Muy_Larga);

        }

        [Test]
        public void insertarUsuario_UsuarioMuyCorto_ReturnsUsuario_Muy_Corto()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Jonnathan", "Perez", "Picado", "jonapicado@gmail.com", "San Rafael Arriba, Desamparados", "Jona", "jona45pp", "82145767");
            Assert.AreEqual(resultado, Usuario_Muy_Corto);

        }

        [Test]
        public void insertarUsuario_UsuarioMuyLargo_ReturnsUsuario_Muy_Largo()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Marisol", "Carranza", "Lopez", "marisolcarranza@gmail.com", "Bebedero, Escazú", "Marisol_04_CarranzaLopez", "mari04cl", "83410868");
            Assert.AreEqual(resultado, Usuario_Muy_Largo);

        }

        [Test]
        public void insertarUsuario_TelefonoNoNumerico_ReturnsDato_No_Numerico()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Sandra", "Hernández", "Pizarro", "sandrahp05@gmail.com", "El Carmen, Escazú", "sandra15cc", "sandra15hp", "2a2b8h2o");
            Assert.AreEqual(resultado, Dato_No_Numerico);

        }

        [Test]
        public void insertarUsuario_ContraseñaNoTieneLetras_ReturnsNo_Contiene_Letras()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Liza", "Fernández", "Parajeles", "lizach07@gmail.com", "Sabanilla, San Pedro", "lizchv07", "987987904", "85187797");
            Assert.AreEqual(resultado, No_Contiene_Letras);

        }

        [Test]
        public void insertarUsuario_ContraseñaNoTieneNumeros_ReturnsNo_Contiene_Numeros()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("María", "Arce", "Montoya", "maria78am@gmail.com", "San Joaquín de Flores, Heredia", "maria78am", "PassWord", "86225767");
            Assert.AreEqual(resultado, No_Contiene_Numeros);

        }

        [Test]
        public void insertarUsuario_VerificarEspaciosVacios_ReturnsEspacio_Vacio()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Daniel", "", "", "", "Santo Domingo, Heredia", "daniel79m", "daniel79m", "81245767");
            Assert.AreEqual(resultado, Espacio_Vacio);

        }
    }
}
