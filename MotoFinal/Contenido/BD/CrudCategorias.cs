using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MotoFinal.Models;
using System.IO;
using System.Drawing;

namespace MotoFinal.Contenido.BD
{
    public class CrudCategorias
    {
        //Este metodo permite la conexión con la base de datos, y obtenemos todos los datos
        //disponibles de la tabla de categorias y retornamos una lista de categorias
        public List<Categoria> obtenerTodos()
        {
            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            List<Categoria> lista = new List<Categoria>();
            string sql = "select idCategoria, nombre, descripcion, imagen from categoria";
            MySqlCommand comando = new MySqlCommand(sql, conexion.conexion);
            MySqlDataReader dataReader = comando.ExecuteReader();
            while (dataReader.Read())
            {
                Categoria categoria = new Categoria();

                categoria.idCategoria = int.Parse(dataReader[0].ToString());
                categoria.nombre = dataReader[1].ToString();
                categoria.descripcion = dataReader[2].ToString();
                categoria.imagen = (byte[])dataReader[3];
                lista.Add(categoria);
            }
            return lista;
        }
    }
}