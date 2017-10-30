/**
 *	Interface IInsertarUsuario
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


namespace CRM_Proyect.Modelo.ClassTest
{
    /**
    *	Interface que contiene los métodos necesarios para probar el registro de usuarios en la base de datos.
    *
    */
    public interface IInsertarUsuario
    {
        Boolean validarCorreo (string correo);
        Boolean validarUsuario(string usuario);
        int InsertarUsuarioBD(string nombre, string primerApellido, string segundoApellido, string correo,
                        string direccion, string usuario, string contrasena, string telefono);
        int insertarEmpresa(string nombre, string correo, string direccion, string telefono,
            string usuario, string contrasena);
    }
}
