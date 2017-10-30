/**
 *	Clase ValidadorDatosUsuario
 *	
 *	Version 1.0
 *	
 *	27/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */
using System;
using CRM_Proyect.Modelo.ClassTest;

namespace CRM_Tests
{

    /**
    *	Clase para validar los datos del usuario ingresados.
    *
    */
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
