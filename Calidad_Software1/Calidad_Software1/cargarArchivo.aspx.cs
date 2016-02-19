using CAPA_LOGICA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calidad_Software1
{
    public partial class cargarArchivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Boolean fileOK = false;
                String path = "C:\\Archivos\\";
                if (cargarExcel.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(cargarExcel.FileName).ToLower();
                    String[] allowedExtensions =
                        {".xls", ".xlsx"};
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        string excelPath = Server.MapPath("~/Archivos/") + Path.GetFileName(cargarExcel.PostedFile.FileName);
                        cargarExcel.SaveAs(excelPath);
                        string extension = Path.GetExtension(cargarExcel.PostedFile.FileName);

                        Asociado asoc = new Asociado();

                        asoc.insertarAsociado(cargarExcel.FileName, extension, excelPath);
                        lblCargar.Text = "Archivo Cargado";
                    }
                    catch (Exception ex)
                    {
                        string msj = "No fue posible cargar el archivo.";
                        if (ex.Message.Contains("does not allow DBNull.Value"))
                        {
                            msj = "El archivo contiene filas en blanco, favor removerlas antes de proceder.";
                        }
                        lblCargar.Text = msj;
                    }
                }
                else
                {
                    lblCargar.Text = "Extensión no permitida";
                }
            }
        }
    }
}