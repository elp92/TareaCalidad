using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CAPA_DATOS
{
    public class AsociadoDAL
    {
        public AsociadoDAL() { }

        public void Insertar(string fileName, string extension, string excelPath)
        {
            string conString = string.Empty;

            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07 or higher
                    conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ToString();
                    break;

            }
            conString = string.Format(conString, excelPath);
            using (OleDbConnection excel_con = new OleDbConnection(conString))
            {
                excel_con.Open();
                string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                DataTable dtExcelData = new DataTable();

                //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                /*dtExcelData.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Salary",typeof(decimal)) });*/

                using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                {
                    oda.Fill(dtExcelData);
                }
                excel_con.Close();

                string consString = Persistencia_Datos.getInstance().getConnection();
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.ASOCIADO";

                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        /*sqlBulkCopy.ColumnMappings.Add("Id", "PersonId");
                        sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                        sqlBulkCopy.ColumnMappings.Add("Salary", "Salary");*/
                        con.Open();
                        sqlBulkCopy.WriteToServer(dtExcelData);
                        con.Close();
                    }
                }
            }



            /*     string conex = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Archivos\\" + fileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";

                   OleDbConnection conn = new OleDbConnection(conex);
                   conn.Open();

                   string qry = "Select * from [Hoja1$]";

                   OleDbDataAdapter da = new OleDbDataAdapter(qry, conn);
                   DataSet dsXLS = new DataSet();
                   da.Fill(dsXLS);
                   DataView dvLocations = new DataView(dsXLS.Tables[0]);

                   Database db = DatabaseFactory.CreateDatabase("Default");

                   SqlCommand comando = new SqlCommand("usp_INSERT_ASOCIADO");
                   comando.CommandType = CommandType.StoredProcedure;

                   foreach (DataRow row in dvLocations.Table.Rows)
                   {
                       List<object> lista = row.ItemArray.ToList();
                       comando.Parameters.AddWithValue("@id", lista[0].ToString());
                       comando.Parameters.AddWithValue("@nombre", lista[1].ToString());
                       comando.Parameters.AddWithValue("@cedula", lista[2].ToString());
                       comando.Parameters.AddWithValue("@estado1", (lista[3].ToString().Equals("Activo") ? "1" : "0"));
                       comando.Parameters.AddWithValue("@estado2", (lista[4].ToString().Equals("Confirmado") ? "1" : "0"));
                       comando.Parameters.AddWithValue("@correo", lista[5].ToString());
                       comando.Parameters.AddWithValue("@telefono", lista[6].ToString());

                       db.ExecuteReader(comando,"ASOCIADO");
                       comando.Parameters.Clear();
                   }
                   */

        }

    }
}