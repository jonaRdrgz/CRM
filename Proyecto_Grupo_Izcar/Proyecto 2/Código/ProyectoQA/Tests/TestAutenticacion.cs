using NUnit.Framework;
using System;
using System.Configuration;
using System.Web;


namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestAutenticacion
    {
        [TestCase]
        public void autenticacion_CredencialesInvalidas_NoSession()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            Autenticacion autenticacion = new Autenticacion(fakeConexion);
            autenticacion.autenticar("jefalva@live.com", "12345678");

            String idUser;
            if (HttpContext.Current == null)
                idUser = ConfigurationManager.AppSettings["idUsuario"];
            else
                idUser = HttpContext.Current.Session["idUsuario"].ToString();

            Assert.IsNull(idUser);
        }
        [TestCase]
        public void autenticacion_CredencialesValidas_ThrowsException()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, true);
            Autenticacion autenticacion = new Autenticacion(fakeConexion);
            Assert.Catch<HttpException>(() => autenticacion.autenticar("jefalva@live.com", "12345678"));
        }
    }}