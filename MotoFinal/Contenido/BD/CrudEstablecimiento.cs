using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MotoFinal.Models;
using System.Web.Helpers;

namespace MotoFinal.Contenido.BD
{
    public class CrudEstablecimiento
    {
        public List<Establecimiento> obtenerEstablecimientosPorCategoria(string idCategoria) {
            List<Establecimiento> lista = new List<Establecimiento>();
            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            string sql = "select e.IdEstablecimiento, e.Nombre, e.Telefono1, e.Telefono2, " +
            "e.Correo, e.PaginaWeb, e.Estatus, e.FotoPerfil, e.FotoPortada, e.Descripcion " +
            "from establecimiento e join categoria_has_establecimiento che " +
            "on e.IdEstablecimiento = che.establecimiento_IdEstablecimiento " +
            "join categoria c on c.idCategoria = che.categoria_idCategoria " +
            "where c.idCategoria = @idCategoria;";
            MySqlCommand command = new MySqlCommand(sql, conexion.conexion);
            command.Parameters.AddWithValue("@idCategoria", idCategoria);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read()) {
                Establecimiento establecimiento = new Establecimiento();
                establecimiento.idEstablecimiento = int.Parse(dataReader[0].ToString());
                establecimiento.nombre = dataReader[1].ToString();
                establecimiento.telefono1 = dataReader[2].ToString();
                establecimiento.telefono2 = dataReader[3].ToString();
                establecimiento.correo = dataReader[4].ToString();
                establecimiento.paginaWeb = dataReader[5].ToString();
                establecimiento.estatus = dataReader[6].ToString();
                try
                {
                    establecimiento.fotoPerfil = (byte[])dataReader[7];
                    establecimiento.fotoPortada = (byte[])dataReader[8];
                }
                catch (Exception e) { }

                establecimiento.descripcion = dataReader[9].ToString();
                lista.Add(establecimiento);
            }
            conexion.cerrarConexion();
            return lista;
        }
        public void insertar(Usuario usuario, Establecimiento establecimiento, Domicilio domicilio, string idCategoria) {

            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            MySqlTransaction transaction = conexion.conexion.BeginTransaction();
            try {
                string sql = "INSERT INTO usuario (NombreUsuario, Contrasena, Nombre, Apellido1, Apellido2, Sexo, FechaNacimiento, Telefono) " +
                    "VALUES (@NombreUsuario, @Contrasena, @Nombre, @Apellido1, @Apellido2, @Sexo, @FechaNacimiento, @Telefono);";
                MySqlCommand command = new MySqlCommand(sql, conexion.conexion);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@NombreUsuario", usuario.nombreUsuario);
                command.Parameters.AddWithValue("@Contrasena", usuario.contrasena);
                command.Parameters.AddWithValue("@Nombre", usuario.nombre);
                command.Parameters.AddWithValue("@Apellido1", usuario.apellido1);
                command.Parameters.AddWithValue("@Apellido2", usuario.apellido2);
                command.Parameters.AddWithValue("@Sexo", usuario.sexo);
                command.Parameters.AddWithValue("@FechaNacimiento", usuario.fechaNacimiento);
                command.Parameters.AddWithValue("@Telefono", usuario.telefono);
                command.ExecuteNonQuery();

                string sqlEstablecimiento = "INSERT INTO establecimiento (IdEstablecimiento, Nombre, Telefono1, Telefono2, Correo, PaginaWeb, Estatus, FotoPerfil, FotoPortada, Descripcion) " +
                    "VALUES (@IdEstablecimiento, @Nombre, @Telefono1, @Telefono2, @Correo, @PaginaWeb, @Estatus, @FotoPerfil, @FotoPortada, @Descripcion); ";
            
                MySqlCommand mySqlCommandEstablecimiento = new MySqlCommand(sqlEstablecimiento, conexion.conexion);
                mySqlCommandEstablecimiento.CommandType = System.Data.CommandType.Text;
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@IdEstablecimiento", null);
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@Nombre", establecimiento.nombre);
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@Telefono1", establecimiento.telefono1);
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@Telefono2", establecimiento.telefono2);
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@Correo", establecimiento.correo);
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@PaginaWeb", establecimiento.paginaWeb);
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@Estatus", establecimiento.estatus);
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@FotoPerfil", establecimiento.fotoPerfil);
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@FotoPortada", establecimiento.fotoPortada);
                mySqlCommandEstablecimiento.Parameters.AddWithValue("@Descripcion", establecimiento.descripcion);

                mySqlCommandEstablecimiento.ExecuteNonQuery();

                string sqlEstablecimientoUltimoId = "SELECT LAST_INSERT_ID();";
                MySqlCommand commandEstablecimientoId = new MySqlCommand(sqlEstablecimientoUltimoId, conexion.conexion);

                establecimiento.idEstablecimiento= int.Parse(commandEstablecimientoId.ExecuteScalar().ToString());
                

                string sqlEmpresario = "INSERT INTO empresario(idempresario, usuario_NombreUsuario, establecimiento_IdEstablecimiento) " +
                    "VALUES (@idempresario, @usuario_NombreUsuario, @establecimiento_IdEstablecimiento)";
                MySqlCommand commandEmpresario = new MySqlCommand(sqlEmpresario, conexion.conexion);
                commandEmpresario.CommandType = System.Data.CommandType.Text;
                commandEmpresario.Parameters.AddWithValue("@idempresario", null);
                commandEmpresario.Parameters.AddWithValue("@usuario_NombreUsuario", usuario.nombreUsuario);
                commandEmpresario.Parameters.AddWithValue("@establecimiento_IdEstablecimiento", establecimiento.idEstablecimiento);
                commandEmpresario.ExecuteNonQuery();

                string sqlDomicilio = "INSERT INTO domicilio(idDomicilio, Calle, EntreCalle, YCalle, Tipo, Pais, Estado, Municipio, CodigoPostal, Descripcion, establecimiento_IdEstablecimiento) " +
                    "VALUES(@idDomicilio, @Calle, @EntreCalle, @YCalle, @Tipo, @Pais, @Estado, @Municipio, @CodigoPostal, @Descripcion, @establecimiento_IdEstablecimiento)";
                MySqlCommand commandDomicilio = new MySqlCommand(sqlDomicilio, conexion.conexion);
                commandDomicilio.Parameters.AddWithValue("@idDomicilio", null);
                commandDomicilio.Parameters.AddWithValue("@Calle", domicilio.calle);
                commandDomicilio.Parameters.AddWithValue("@EntreCalle", domicilio.entreCalle);
                commandDomicilio.Parameters.AddWithValue("@YCalle", domicilio.yCalle);
                commandDomicilio.Parameters.AddWithValue("@Tipo", domicilio.tipo);
                commandDomicilio.Parameters.AddWithValue("@Pais", domicilio.pais);
                commandDomicilio.Parameters.AddWithValue("@Estado", domicilio.estado);
                commandDomicilio.Parameters.AddWithValue("@Municipio", domicilio.municipio);
                commandDomicilio.Parameters.AddWithValue("@CodigoPostal", domicilio.codigoPostal);
                commandDomicilio.Parameters.AddWithValue("@Descripcion", domicilio.descripcion);
                commandDomicilio.Parameters.AddWithValue("@establecimiento_IdEstablecimiento", establecimiento.idEstablecimiento);
                commandDomicilio.ExecuteNonQuery();

                string sqlDetalleCategoria = "INSERT INTO categoria_has_establecimiento(categoria_idCategoria, establecimiento_IdEstablecimiento) " +
                    "VALUES(@categoria_idCategoria, @establecimiento_IdEstablecimiento);";
                MySqlCommand commandDetalle = new MySqlCommand(sqlDetalleCategoria, conexion.conexion);
                commandDetalle.Parameters.AddWithValue("@categoria_idCategoria", idCategoria);
                commandDetalle.Parameters.AddWithValue("@establecimiento_IdEstablecimiento", establecimiento.idEstablecimiento);
                commandDetalle.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (MySqlException ex) {
                transaction.Rollback();
            }
            finally{
                conexion.cerrarConexion();
            }
        }
        public List<Establecimiento> obtenerTodos()
        {
            ConexionBd conexion = new ConexionBd();
            conexion.abrirConexion();
            List<Establecimiento> lista = new List<Establecimiento>();
            string sql = "select IdEstablecimiento, Nombre, Telefono1, Telefono2, Correo, PaginaWeb, Estatus, FotoPerfil, FotoPortada, Descripcion from establecimiento;";
            MySqlCommand comando = new MySqlCommand(sql, conexion.conexion);
            MySqlDataReader dataReader = comando.ExecuteReader();
            while (dataReader.Read())
            {
                Establecimiento establecimiento = new Establecimiento();

                establecimiento.idEstablecimiento= int.Parse(dataReader[0].ToString());
                establecimiento.nombre= dataReader[1].ToString();
                establecimiento.telefono1 = dataReader[2].ToString();
                establecimiento.telefono2 = dataReader[3].ToString();
                establecimiento.correo = dataReader[4].ToString();
                establecimiento.paginaWeb = dataReader[5].ToString();
                establecimiento.estatus = dataReader[6].ToString();
                try {
                    establecimiento.fotoPerfil = (byte[])dataReader[7];
                    establecimiento.fotoPortada = (byte[])dataReader[8];
                }
                catch (Exception e) { }
               
                establecimiento.descripcion = dataReader[9].ToString();

                lista.Add(establecimiento);
            }
            return lista;
        }
    }
}