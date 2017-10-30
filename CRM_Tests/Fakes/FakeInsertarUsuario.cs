using System;
using CRM_Proyect.Modelo.ClassTest;

namespace CRM_Tests.Fakes
{
    public class FakeInsertarUsuario : IInsertarUsuario
    {
        public Boolean debeResponder = false;
        public int resultadoExitoso = 0;

        public Boolean validarCorreo(string correo)
        {
            return debeResponder;
        }

        public Boolean validarUsuario(string correo)
        {
            return debeResponder;
        }

        public int InsertarUsuarioBD(string nombre, string primerApellido, string segundoApellido, string correo,
                        string direccion, string usuario, string contrasena, string telefono)
        {
            return resultadoExitoso;
        }
        public int insertarEmpresa(string nombre, string correo, string direccion,
            string telefono, string usuario, string contrasena)
        {
            return resultadoExitoso;

        }
    }
}
