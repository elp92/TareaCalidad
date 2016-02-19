using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAPA_LOGICA
{
    public class Asociado
    {
        #region Attributes
        private string nombre;
        private string cedula;
        private string estado1;
        private string estado2;
        private string correo;
        private string telefono;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
        public string Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
            }
        }
        public string Estado1
        {
            get
            {
                return estado1;
            }

            set
            {
                estado1 = value;
            }
        }
        public string Estado2
        {
            get
            {
                return estado2;
            }

            set
            {
                estado2 = value;
            }
        }
        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }
        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        #endregion

        public Asociado() { }

        public Asociado(string nombreP, string cedulaP, string estado1P, string estado2P, string correoP, string telefonoP) {
            nombre = nombreP;
            cedula = cedulaP;
            estado1 = estado1P;
            estado2 = estado2P;
            correo = correoP;
            telefono = telefonoP;
        }

        public string insertarAsociado(string fileName) {

            AsociadoDAL asocDal = new AsociadoDAL();

            asocDal.Insertar(fileName);

            return "";
        }

    }
}