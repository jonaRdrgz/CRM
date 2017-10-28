/**
 *	Clase Tests_Respuestas_Propuestas_Ventas
 *	
 *	Version 1.0
 *	
 *	26/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */
using System.Collections.Generic;
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

