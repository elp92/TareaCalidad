using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Logica;

namespace Calidad_Software1
{
    public partial class _Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre_usuario"] != null)
            {
               panelLogin.Visible = false;
               // HttpContext.Current.Session["user"] = Session["nombre_usuario"].ToString();
                lblInicio.Text = "Bienvenido "+ Session["nombre_usuario"].ToString();
                //Your Login/logout Link Logic goes here
            }
            else
                panelLogin.Visible = true;

        }




        private void autenticarUsuario()
        {
            if (Page.IsValid)
            {
                if (Usuario.Autenticar(txtNombre_Usuario.Text, txtPassword.Text))
                {
                    Session.Add("nombre_usuario", txtNombre_Usuario.Text);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMessage.Text = "El usuario no existe o la contrasenna es incorrecta.";
                }

            }
            else
            {
                lblMessage.Text = "Debe ingresar los datos de la imagen arriba.";
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            autenticarUsuario();
        }
    }
}