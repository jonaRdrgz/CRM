using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoQA.Tests
{
    [TestFixture]
    public class TestPuntosContacto
    {
        [TestCase]
        public void consultarVendedores_visualizarContactos_ReturnListNull()
        {
            FakePuntosdeContacto instancia = new FakePuntosdeContacto();
            List<Usuario> resultado = instancia.consultarVendedores();
            Assert.AreEqual(resultado, null);
        }

    }
}