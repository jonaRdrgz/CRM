/**
 *	Clase FakeConsulta
 *	
 *	Version 1.0
 *	
 *	26/10/2017
 *
 *	Jonathan Rodríguez
 *	Melissa Molina Corrales
 *	Edwin Cen Xu
 */

using System;
using System.Collections.Generic;
using CRM_Proyect.Modelo;

namespace CRM_Tests.Fakes
{
    public class FakeConsulta : IConsulta
    {
        private int idUsuarioActual = -1;
        private String usuarioValido = "Admin";
        private String contraseñaValida = "1234567p";
        public int idContacto = 1;
        public int idEmpresa = 1;
        public List<Usuario> listaUsuarios = new List<Usuario>();
        public List<Empresa> listaEmpresas = new List<Empresa>();

        public Boolean validarUsuario(string usuario, string contrasena)
        {
            if (usuario.Equals(usuarioValido) && contrasena.Equals(contraseñaValida))
            {
                return true;
            }
            return false;
        }
        public Boolean registarContactoPersona(int idPersona) {
            return idContacto == idPersona;
        }
        public void setIdUsuarioActual(int nuevoId) {
            this.idUsuarioActual = nuevoId;
        }

        public Boolean registarContactoEmpresa(int idEmpresa) {
            return this.idEmpresa == idEmpresa;
        }

        public Boolean borrarContactoEmpresa(int idEmpresa) {
            return this.idEmpresa == idEmpresa;
        }
        public Boolean borrarContacto(int idPersona) {
            return this.idContacto == idPersona;
        }
        public List<Usuario> obtenerContactoPersonas() {
            return listaUsuarios;
        }
        public List<Empresa> obtenerContactoEmpresas() {
            return listaEmpresas;
        }
    }
}