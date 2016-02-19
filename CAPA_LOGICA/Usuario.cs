using Capa_Datos;
using CAPA_LOGICA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capa_Logica
{
    /// <summary>
    /// Clase para manipulación de los usuarios.
    /// </summary>
    public class Usuario
    {
        public int Id  { set; get; }
        public string Nombre { get; set; }
        public Perfil Perfil { get; set; }
        public string Contrasena { get; set; }




        public Usuario()
        {

        }
       /// <summary>
       /// Metodo para agregar un nuevo usuario
       /// </summary>
       /// <param name="nombre_usuario"></param>
       /// <param name="id_perfil"></param>
       /// <param name="contrasena"></param>
       /// <returns></returns>
        public static bool RegistrarUsuario(string nombre_usuario, int id_perfil, string contrasena)
        {
            try
            {

                //cadena conexion
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ToString()))
                {
                    conn.Open();//abrimos conexion

                    SqlCommand oCommand = new SqlCommand("[dbo].[Sp_Registrar_Usuario]", conn);

                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@nombre_usuario", nombre_usuario); //enviamos los parametros
                    oCommand.Parameters.AddWithValue("@contrasena", contrasena);
                    oCommand.Parameters.AddWithValue("@id_perfil", id_perfil);
                    int count = Persistencia_Datos.getInstance().ejecutarActualizacionSql(oCommand);  //devuelve la fila afectada

                    if (count == 0)
                        return false;
                    else
                        return true;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }






        /// <summary>
        /// Metodo para validar el ingreso de un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Autenticar(string usuario, string password)
        {

            try
            {

                //cadena conexion
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection_Login"].ToString()))
                {
                    conn.Open();//abrimos conexion

                    SqlCommand oCommand = new SqlCommand("[dbo].[Sp_Validar_Usuario]", conn);

                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@nombre_usuario", usuario); //enviamos los parametros
                    oCommand.Parameters.AddWithValue("@password", password);
                    int count = Persistencia_Datos.getInstance().ejecutarConsultaScalarSql(oCommand);  //devuelve la fila afectada

                    if (count == 0)
                        return false;
                    else
                        return true;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// <summary>
        /// Metodo para listar los usuarios existentes.
        /// </summary>
        /// <returns></returns>

        public static DataTable listarUsuarios()
        {
            try
            {

                //cadena conexion
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ToString()))
                {
                    conn.Open();//abrimos conexion

                    SqlCommand oCommand = new SqlCommand("[dbo].[Sp_Listar_Usuarios]", conn); //ejecutamos la instruccion

                    oCommand.CommandType = CommandType.StoredProcedure;
                    return Persistencia_Datos.getInstance().ejecutarConsultaDataTableSql(oCommand);  //devuelve la tabla

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Metodo para consultar el correo del usuario actual.
        /// </summary>
        /// <param name="nombre_usuario"></param>
        /// <returns></returns>
        public static string ConsultarCorreo(string nombre_usuario)
        {
            try
            {

                string correo = null;
                //cadena conexion
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ToString()))
                {
                    conn.Open();//abrimos conexion

                    SqlCommand oCommand = new SqlCommand("[dbo].[Sp_Consultar_Correo]", conn); //ejecutamos la instruccion

                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@nombre_usuario", nombre_usuario);
                    SqlDataReader tabla = Persistencia_Datos.getInstance().ejecutaConsultaDataReader(oCommand);  //devuelve la tabla

                    while (tabla.Read())
                    {
                        correo = tabla.GetString(0);
                    }


                    return correo;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool CambiarContrasenna(string nombre_usuario, string nueva_contrasenna)
        {
            try
            {

                //cadena conexion
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection_Login"].ToString()))
                {
                    conn.Open();//abrimos conexion

                    SqlCommand oCommand = new SqlCommand("[dbo].[Sp_Cambiar_Contrasenna]", conn);

                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@nombre_usuario", nombre_usuario); //enviamos los parametros
                    oCommand.Parameters.AddWithValue("@nueva_contrasenna", nueva_contrasenna);
                    int count = Persistencia_Datos.getInstance().ejecutarActualizacionSql(oCommand);  //devuelve la fila afectada



                    if (count == 0)
                        return false;
                    else
                        return true;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ActualizarUsuario(string nombre_usuario, string correo, DateTime fechaNacimiento, string telefono)
        {
            try
            {

                //cadena conexion
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection_Login"].ToString()))
                {
                    conn.Open();//abrimos conexion

                    SqlCommand oCommand = new SqlCommand("[dbo].[Sp_Actualizar_Usuario]", conn);

                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@nombre_usuario", nombre_usuario); //enviamos los parametros
                    oCommand.Parameters.AddWithValue("@correo", correo);
                    oCommand.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento);
                    oCommand.Parameters.AddWithValue("@telefono", telefono);
                    int count = Persistencia_Datos.getInstance().ejecutarActualizacionSql(oCommand);  //devuelve la fila afectada



                    if (count == 0)
                        return false;
                    else
                        return true;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        /// <summary>
        /// Metodo para consultar los mesese transcurridos desde el ultimo cambio de contrasenna.
        /// </summary>
        /// <param name="nombre_usuario"></param>
        /// <returns></returns>
        public static int ConsultarUltimoCambioContrasenna(string nombre_usuario)
        {
            try
            {
                int valor = 0;

                //cadena conexion
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection_Login"].ToString()))
                {
                    conn.Open();//abrimos conexion

                    SqlCommand oCommand = new SqlCommand("[dbo].[Sp_Comprobar_Tiempo_Contrasenna]", conn); //ejecutamos la instruccion

                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Parameters.AddWithValue("@nombre_usuario", nombre_usuario);
                    SqlDataReader tabla = Persistencia_Datos.getInstance().ejecutaConsultaDataReader(oCommand);  //devuelve la tabla

                    while (tabla.Read())
                    {
                        valor = tabla.GetInt32(0);
                    }


                    return valor;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }



}