﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CRM_Proyect.Modelo.ClassTest;

namespace CRM_Proyect.Modelo
{
    public class Conexion: IConexion
    {
        private MySqlConnection conexion;
        private MySqlCommand consulta;
        private MySqlDataReader resultados;
        private String servidor;
        private String baseDeDatos;
        private String usuario;
        private String contraseña;
        private String puerto;
        public Conexion(String pServer, String pDatabase, String pUid, String pPassword, String pPort)
        {
            servidor = pServer;
            baseDeDatos = pDatabase;
            usuario = pUid;
            contraseña = pPassword;
            puerto = pPort;

            inicializar();
        }
        private void inicializar()
        {
            String conexionString;
            conexionString = "SERVER=" + servidor + "; PORT=" + puerto + "; DATABASE=" +
            baseDeDatos + ";" + "UID=" + usuario + ";" + "PASSWORD=" + contraseña + ";";

            conexion = new MySqlConnection(conexionString);
            consulta = new MySqlCommand();
            consulta.Connection = conexion;
        }

        public Boolean abrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean cerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean command(String comando)
        {
            try
            {
                consulta.CommandText = comando;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IDataReader obtenerResultados()
        {
            resultados = consulta.ExecuteReader();
            return resultados;
        }
        public MySqlConnection getConexion()
        {
            return conexion;
        }
    }
}