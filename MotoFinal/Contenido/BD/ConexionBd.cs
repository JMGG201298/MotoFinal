using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MotoFinal.Contenido.BD
{
    public class ConexionBd
    {
        public MySqlConnection conexion { get; set; }
        public ConexionBd() { 
            string sql= "datasource = localhost; database = dbmototax; username = root; password = root";
            conexion = new MySqlConnection(sql);
        }
        public void abrirConexion() {
            conexion.Open();
        }
        public void cerrarConexion() {
            conexion.Close();
        }
    }
}