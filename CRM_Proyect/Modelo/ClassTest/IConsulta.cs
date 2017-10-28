/**
 *	interface  IConsulta
 *	
 *	Version 1.0
 *	
 *	22/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Proyect.Modelo
{
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