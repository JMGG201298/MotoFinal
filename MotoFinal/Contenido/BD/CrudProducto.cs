using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MotoFinal.Models;
using MotoFinal.Contenido.BD;
using MySql.Data.MySqlClient;

namespace MotoFinal.Contenido.BD
{
    public class CrudProducto
    {
        public List<Producto> obtenerProductosPorSubCategorias(string idSubcategoria)
        {
            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            List<Producto> lista = new List<Producto>();
            string sql= "SELECT p.IdProducto, p.Nombre, p.ContenidoNeto, p.Precio, "+
                        "p.Descripcion, p.Foto, p.Tipo, p.Proveedor, p.subCategorias_idsubCategorias "+
                        "FROM producto p join subcategorias s "+
                        "on p.subCategorias_idsubCategorias = s.idsubCategorias "+
                        "where s.idsubCategorias = @id; ";
            MySqlCommand command = new MySqlCommand(sql, conexion.conexion);
            command.Parameters.AddWithValue("@id", idSubcategoria);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read()) {
                Producto producto = new Producto();
                producto.idProducto = dataReader[0].ToString();
                producto.nombre = dataReader[1].ToString();
                producto.contenidoNeto = dataReader[2].ToString();
                producto.precio = dataReader[3].ToString();
                producto.descripcion = dataReader[4].ToString();
                try
                {
                    producto.foto = (byte[])dataReader[5];
                }
                catch (Exception e) { }

                producto.tipo = dataReader[6].ToString();
                producto.proveedor = dataReader[7].ToString();
                producto.subCategorias_idSubCategorias = dataReader[8].ToString();
                lista.Add(producto);
            }
            return lista;

        }
        public List<Producto> obtenerProductosPorEstablecimiento(string idEstablecimiento) {
            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            List<Producto> lista = new List<Producto>();
            string sql = "select p.idProducto, p.Nombre, p.ContenidoNeto, " +
            "P.precio, p.descripcion, p.Foto, p.Tipo, p.Proveedor, p.subCategorias_idsubCategorias from categoria_has_establecimiento ches " +
            "join establecimiento e on ches.establecimiento_IdEstablecimiento = e.IdEstablecimiento " +
            "join categoria c on ches.categoria_idCategoria = c.idCategoria " +
            "join subcategorias s on s.establecimiento_IdEstablecimiento = e.IdEstablecimiento " +
            "join producto p on p.subCategorias_idsubCategorias = s.idSubcategorias " +
             "where e.idEstablecimiento = @idEstablecimiento; ";
            MySqlCommand command = new MySqlCommand(sql, conexion.conexion);
            command.Parameters.AddWithValue("@idEstablecimiento", idEstablecimiento);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read()) {
                Producto producto = new Producto();
                producto.idProducto = dataReader[0].ToString();
                producto.nombre = dataReader[1].ToString();
                producto.contenidoNeto = dataReader[2].ToString();
                producto.precio = dataReader[3].ToString();
                producto.descripcion = dataReader[4].ToString();
                try
                {
                    producto.foto = (byte[])dataReader[5];
                }
                catch (Exception e) { }

                producto.tipo = dataReader[6].ToString();
                producto.proveedor = dataReader[7].ToString();
                producto.subCategorias_idSubCategorias = dataReader[8].ToString();
                lista.Add(producto);
            }
            return lista;
        }
        public List<Producto> obtenerTodos() {
            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            List<Producto> lista = new List<Producto>();
            string sql = "Select IdProducto, Nombre, ContenidoNeto, Precio, Descripcion, Foto, Tipo, Proveedor, subCategorias_idsubCategorias from producto";
            MySqlCommand command = new MySqlCommand(sql, conexion.conexion);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read()) {
                Producto producto = new Producto();
                producto.idProducto = dataReader[0].ToString();
                producto.nombre = dataReader[1].ToString();
                producto.contenidoNeto = dataReader[2].ToString();
                producto.precio = dataReader[3].ToString();
                producto.descripcion = dataReader[4].ToString();
                try
                {
                    producto.foto = (byte[])dataReader[5];
                }
                catch (Exception e) { }
                
                producto.tipo = dataReader[6].ToString();
                producto.proveedor = dataReader[7].ToString();
                producto.subCategorias_idSubCategorias = dataReader[8].ToString();
                lista.Add(producto);
            }
            return lista;
        }
    }
}