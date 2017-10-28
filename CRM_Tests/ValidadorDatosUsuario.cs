using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_Proyect.Modelo.ClassTest;
namespace CRM_Tests
{
    class ValidadorDatosUsuario
    {
        private IInsertarUsuario manager;

        public ValidadorDatosUsuario(IInsertarUsuario mgr) {
            manager = mgr;
        }


        public Boolean validarCorreo(String correo) {
            return manager.validarCorreo(correo);
        }
        public Boolean validarUsuario(String usuario)
        {
            return manager.validarUsuario( usuario);
        }
        public int InsertarUsuarioBD(string nombre, string primerApellido, string segundoApellido,
            string correo,string direccion, string usuario, string contrasena, string telefono)
        {
            return manager.InsertarUsuarioBD(nombre, primerApellido,segundoApellido,correo, 
                direccion,usuario, contrasena, telefono);
        }
        public int insertarEmpresa(string nombre, string correo, string direccion, string telefono,
            string usuario, string contrasena)
        {
            return manager.insertarEmpresa(nombre, correo, direccion, telefono, usuario,
                contrasena);
        }
    }
}
