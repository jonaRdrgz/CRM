using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CRM_Proyect.Modelo;

namespace CRM_Tests
{
    [TestFixture]
    class Tests_Manejo_Usuarios
    {

        private int EXITO_DE_INSERCION = 0;
        private int FALLO_DE_INSERCION = -1;
        private int CONTRASEÑA_MUY_CORTA = -2;
        private int CONTRASEÑA_MUY_LARGA = -4;
        private int USUARIO_MUY_CORTO = -3;
        private int NO_CONTIENE_LETRAS = -5;
        private int NO_CONTIENE_NUMEROS = -6;
        private int DATO_NO_NUMERICO = -7;
        private int USUARIO_MUY_LARGO = -8;
        private int ESPACIO_VACIO = -9;
        /*Pruebas para Manejo de Acceso y Usuarios*/

        [Test]
        public void validarUsuario_UsuarioyContraseñaValidos_ReturnsTrue()
        {
            var instancia = new Consulta();
            var resultado = instancia.validarUsuario("JonaRdrgz", "PassWord123");
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void validarUsuario_UsuarioValidoyContraseñaIncorrecta_ReturnsFalse()
        {
            var instancia = new Consulta();
            var resultado = instancia.validarUsuario("JonaRdrgz", "PassIncorrecta");
            Assert.AreEqual(resultado, false);

        }

        [Test]
        public void validarUsuario_UsuarioInvalidoyContraseñaCorrecta_ReturnsFalse()
        {
            var instancia = new Consulta();
            var resultado = instancia.validarUsuario("Jona", "PassWord123");
            Assert.AreEqual(resultado, false);

        }

        [Test]
        public void validarCorreo_VerificarCorreoExistente_ReturnsTrue()
        {
            var instancia = new InsertarUsuario();
            var resultado = instancia.validarCorreo("francAlv@gmail.com");
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void validarCorreo_VerificarCorreoNoExistente_ReturnsFalse()
        {
            var instancia = new InsertarUsuario();

            var resultado = instancia.validarCorreo("rocio1308@gmail.com");
            Assert.AreEqual(resultado, false);

        }


        [Test]
        public void validarUsuario_VerificarUsuarioExistente_ReturnsTrue()
        {
            var instancia = new InsertarUsuario();
            var resultado = instancia.validarUsuario("JonaRdrgz");
            Assert.AreEqual(resultado, true);

        }

        [Test]
        public void InsertarUsuarioBD_RegistrarUsuarioCorrecto_ReturnsEXITO_DE_INSERCION()
        {
            var instancia = new InsertarUsuario();
            var resultado = instancia.InsertarUsuarioBD("Carlos", "Gutierrez", "Rodríguez", "carlosgr@gmail.com", "San Rafael Abajo, Desamparados", "carlosgr", "carlosgr0508jt", "85167747");
            Assert.AreEqual(resultado, EXITO_DE_INSERCION);

        }

        [Test]
        public void InsertarUsuarioBD_RegistrarUsuarioIncorrecto_ReturnsFALLO_DE_INSERCION()
        {
            //Usuario no deberia poder registrarse con un nombre de usuario que ya existe: "JonaRdrgz"
            var instancia = new InsertarUsuario();
            var resultado = instancia.InsertarUsuarioBD("Andrés", "Jiménez", "Molina", "andresjm@gmail.com", "San Rafael Abajo, Desamparados", "JonaRdrgz", "andresjm0508jt", "87137547");
            Assert.AreEqual(resultado, FALLO_DE_INSERCION);

        }


        [Test]
        public void insertarEmpresa_RegistrarEmpresaCorrecto_ReturnsEXITO_DE_INSERCION()
        {

            var instancia = new InsertarUsuario();
            var resultado = instancia.insertarEmpresa("Samsung", "samsungcr@gmail.com", "Sabana Oeste", "22288929", "samsungcr", "samsung2510");
            Assert.AreEqual(resultado, EXITO_DE_INSERCION);

        }

        [Test]
        public void InsertarEmpresa_RegistrarEmpresaIncorrecto_ReturnsFALLO_DE_INSERCION()
        {
            //Poner nombre de usuario que ya existe en la base
            var instancia = new InsertarUsuario();
            var resultado = instancia.insertarEmpresa("Digitel", "digitelcr@gmail.com", "San Pedro", "22482879", "intelcr", "samsung2510");
            Assert.AreEqual(resultado, FALLO_DE_INSERCION);

        }

        [Test]
        public void insertarUsuario_ContraseñaMuyCorta_ReturnsCONTRASEÑA_MUY_CORTA()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Gabriel", "Hernández", "Picado", "gabrielhp@gmail.com", "San Rafael Abajo, Desamparados", "gabo13hp", "gab13", "84167767");
            Assert.AreEqual(resultado, CONTRASEÑA_MUY_CORTA);

        }

        [Test]
        public void insertarUsuario_ContraseñaMuyLarga_ReturnsCONTRASEÑA_MUY_LARGA()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Alejandra", "Carranza", "Chaves", "alecarranza04@gmail.com", "San Antonio,Escazú", "ale56cc", "Esta_es_una_contraseña_muy_larga_para_pruebas_solamente", "85169767");
            Assert.AreEqual(resultado, CONTRASEÑA_MUY_LARGA);

        }

        [Test]
        public void insertarUsuario_UsuarioMuyCorto_ReturnsUSUARIO_MUY_CORTO()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Jonnathan", "Perez", "Picado", "jonapicado@gmail.com", "San Rafael Arriba, Desamparados", "Jona", "jona45pp", "82145767");
            Assert.AreEqual(resultado, USUARIO_MUY_CORTO);

        }

        [Test]
        public void insertarUsuario_UsuarioMuyLargo_ReturnsUSUARIO_MUY_LARGO()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Melissa", "Molina", "Corrales", "melimolinacorrales@gmail.com", "Bebedero, Escazú", "Melissa_04_MolinaCorrales", "meli04mc", "83410868");
            Assert.AreEqual(resultado, USUARIO_MUY_LARGO);

        }

        [Test]
        public void insertarUsuario_FormatoTelefonoNoNumerico_ReturnsDATO_NO_NUMERICO()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Sandra", "Hernández", "Pizarro", "sandrahp05@gmail.com", "El Carmen, Escazú", "sandra15cc", "sandra15hp", "2a2b8h2o");
            Assert.AreEqual(resultado, DATO_NO_NUMERICO);

        }

        [Test]
        public void insertarUsuario_ContraseñaNoTieneLetras_ReturnsNO_CONTIENE_LETRAS()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Liza", "Fernández", "Parajeles", "lizach07@gmail.com", "Sabanilla, San Pedro", "lizchv07", "987987904", "85187797");
            Assert.AreEqual(resultado, NO_CONTIENE_LETRAS);

        }

        [Test]
        public void insertarUsuario_ContraseñaNoTieneNumeros_ReturnsNO_CONTIENE_NUMEROS()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("María", "Arce", "Montoya", "maria78am@gmail.com", "San Joaquín de Flores, Heredia", "maria78am", "PassWord", "86225767");
            Assert.AreEqual(resultado, NO_CONTIENE_NUMEROS);

        }

        [Test]
        public void insertarUsuario_VerificarEspaciosVacios_ReturnsESPACIO_VACIO()
        {
            var instancia = new Controlador();
            var resultado = instancia.insertarUsuario("Daniel", "", "Mendez", "", "Santo Domingo, Heredia", "daniel79m", "", "81245767");
            Assert.AreEqual(resultado, ESPACIO_VACIO);

        }
    }
}
