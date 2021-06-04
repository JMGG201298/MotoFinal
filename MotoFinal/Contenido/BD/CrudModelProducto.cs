using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MotoFinal.Models;
using MySql.Data.MySqlClient;
using MotoFinal.Contenido.BD;

namespace MotoFinal.Contenido.BD
{
    public class CrudModelProducto
    {
        public List<ModeloProducto> obtenerTodos()
        {
            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            List<ModeloProducto> lista = new List<ModeloProducto>();
            string sqlProducto = "SELECT IdProducto, Nombre, ContenidoNeto, Precio, Descripcion, Foto, Tipo, Proveedor, subCategorias_idsubCategorias from producto;";
            MySqlCommand command = new MySqlCommand(sqlProducto, conexion.conexion);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Producto producto = new Producto();
                producto.idProducto = dataReader[0].ToString();
                producto.nombre = dataReader[1].ToString();
                producto.contenidoNeto = dataReader[2].ToString();
                producto.precio = dataReader[3].ToString();
                producto.descripcion = dataReader[4].ToString();
                producto.foto = (byte[])dataReader[5];
                producto.tipo = dataReader[6].ToString();
                producto.proveedor = dataReader[7].ToString();
                producto.subCategorias_idSubCategorias = dataReader[8].ToString();
                
            }
            return lista;
        }
    }
}