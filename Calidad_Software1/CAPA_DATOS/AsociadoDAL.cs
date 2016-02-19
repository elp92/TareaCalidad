using Capa_Datos;
using System;
using System.Collections.Generic;
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

        public void Insertar(string fileName)
        {
            string conex = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Archivos\\" + fileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";

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
            
            
        }

    }
}