using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MotoFinal.Models;
using MotoFinal.Contenido.BD;
using MySql.Data.MySqlClient;

namespace MotoFinal.Contenido.BD
{
    public class CrudSubcategorias
    {
        public List<Subcategorias> obtenerPorEstablecimiento(string idEstablecimiento) {
            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            List<Subcategorias> lista = new List<Subcategorias>();
            string sql = "select s.idsubCategorias, s.nombre, s.descripcion, s.establecimiento_IdEstablecimiento "+
            "from subcategorias s join establecimiento e "+
            "on s.establecimiento_IdEstablecimiento = e.IdEstablecimiento "+
            "where e.idEstablecimiento = @idEstablecimiento; ";
            MySqlCommand command = new MySqlCommand(sql, conexion.conexion);
            command.Parameters.AddWithValue("@idEstablecimiento", idEstablecimiento);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read()) {
                Subcategorias subcategorias = new Subcategorias();
                subcategorias.idSubcategorias = dataReader[0].ToString();
                subcategorias.nombre = dataReader[1].ToString();
                subcategorias.descripcion = dataReader[2].ToString();
                subcategorias.establecimiento_idEstablecimiento = dataReader[3].ToString();
                lista.Add(subcategorias);
            }
            return lista;
        }
        public List<Subcategorias> obtenerTodos() {
            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            List<Subcategorias> lista = new List<Subcategorias>();
            string sql = "SELECT idsubCategorias, nombre, descripcion, establecimiento_IdEstablecimiento from subcategorias;";
            MySqlCommand command = new MySqlCommand(sql, conexion.conexion);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read()) {
                Subcategorias subcategorias = new Subcategorias();
                subcategorias.idSubcategorias = dataReader[0].ToString();
                subcategorias.nombre = dataReader[1].ToString();
                subcategorias.descripcion = dataReader[2].ToString();
                subcategorias.establecimiento_idEstablecimiento = dataReader[3].ToString();
                lista.Add(subcategorias);
            }
            return lista;
        }

    }
}