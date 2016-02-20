using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS.Tests
{
    [TestClass()]
    public class AsociadoDALTests
    {
        [TestMethod()]
        public void InsertarTest()
        {
            //Arrange
            string path = @"C:\Padron Asociados.xlsx";
            string fileName = "Padron Asociados.xlsx";
            string extension = ".xlsx";

            //Act
            AsociadoDAL asocDal = new AsociadoDAL();
            try
            {
                asocDal.Insertar(fileName, extension, path);
            }
            catch (Exception ex)
            {
                //Asert
                Assert.Fail();
                
            }
        }

        public void InsertarNuloTest()
        {
            //Arrange
            string path = "C:\\";
            string fileName = "";
            string extension = "";

            //Act
            AsociadoDAL asocDal = new AsociadoDAL();
            try
            {
                asocDal.Insertar(fileName, extension, path);
            }
            catch (Exception ex)
            {
                //Asert
                Assert.Fail();

            }
        }
    }
}