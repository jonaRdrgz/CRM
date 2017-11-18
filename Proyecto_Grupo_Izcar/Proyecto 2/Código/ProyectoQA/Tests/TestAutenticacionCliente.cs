using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestAutenticacionCliente
    {
        [TestCase]
        public void autenticacion_CredencialesInvalidas_NoSession()
        {
            IConexion fakeConexion = new FakeConexion(true, true, true, false);
            AutenticacionCliente autenticacion = new AutenticacionCliente(fakeConexion);
            autenticacion.autenticarCliente("jefalva@live.com", "12345678");

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
            AutenticacionCliente autenticacion = new AutenticacionCliente(fakeConexion);
            Assert.Catch<HttpException>(() => autenticacion.autenticarCliente("UrielGomez@gmail.com", "panteras123"));
        }
    }
}