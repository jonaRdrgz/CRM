/**
 *	interface  IConsulta
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
using System.Collections.Generic;

namespace CRM_Proyect.Modelo
{
    /**
    *	Interface que contiene los métodos necesarios para probar el manejo de usuarios.
    *
    */
    public interface  IConsulta
    {
        Boolean validarUsuario(string usuario, string contrasena);
        Boolean registarContactoPersona(int idPersona);
        void setIdUsuarioActual(int nuevoId);
        Boolean registarContactoEmpresa(int idEmpresa);
        Boolean borrarContactoEmpresa(int idEmpresa);
        Boolean borrarContacto(int idPersona);
        List<Usuario> obtenerContactoPersonas();
        List<Empresa> obtenerContactoEmpresas();
    }
}