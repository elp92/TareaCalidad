using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capa_Datos
{
    public class Persistencia_Datos
    {
        private static SqlConnection oSqlConnection = null;
        private static Persistencia_Datos oPersistencia = null;

        public Persistencia_Datos()
        {

            oSqlConnection = new SqlConnection("Data Source=LOPEZPES3\\ESTEBANDB;Initial Catalog=BD_CALIDAD; User ID=sa; Password=123456sa!");
                //ConfigurationManager.con .ConnectionStrings["Connection_Login"].ConnectionString);
            oSqlConnection.Open();
        }

        /// <summary>
        /// Obtener la instancia de conexion mediante el patron singleton.
        /// </summary>
        /// <returns></returns>
        public static Persistencia_Datos getInstance()
        {

            return (oPersistencia == null) ? new Persistencia_Datos() : oPersistencia;


        }


        public int ejecutarActualizacionSql(SqlCommand oCommand)
        {
            try
            {
                oCommand.Connection = oSqlConnection;
                return oCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }


        public DataTable ejecutarConsultaDataTableSql(SqlCommand oCommand)
        {

            try
            {
                oCommand.Connection = oSqlConnection;
                DataTable oDataTable = new DataTable();
                using (SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCommand))
                {
                    oDataAdapter.Fill(oDataTable);
                    return oDataTable;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        public SqlDataReader ejecutaConsultaDataReader(SqlCommand oCommand)
        {
            try
            {

                oCommand.Connection = oSqlConnection;
                return oCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public int ejecutarConsultaScalarSql(SqlCommand oCommand)
        {

            try
            {
                oCommand.Connection = oSqlConnection;
                return Convert.ToInt32(oCommand.ExecuteScalar());

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }





    }
}