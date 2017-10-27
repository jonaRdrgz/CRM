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
    class Tests_Respuestas_Propuestas_Ventas
    {
        [Test]

        public void verComentariosPropuesta_VerComentariosPropuesta_ReturnsList<Comentario>()
        {
            var instancia = new ConsultaComentario();
            List<Comentario> lista = new List<Comentario>();
            var resultado = instancia.verComentariosPropuesta(1);
            Assert.IsNotNull(resultado);

        }

        [Test]

        public void verComentariosEmpresasPropuesta_VerComentariosEmpresasPropuesta_ReturnsList<Comentario>()
        {
            var instancia = new ConsultaComentario();
            List<Comentario> lista = new List<Comentario>();
            var resultado = instancia.verComentariosEmpresasPropuesta(2);
            Assert.IsNotNull(resultado);

        }

    }
}

