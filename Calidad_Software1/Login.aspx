<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Calidad_Software1._Login" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Inicio de Sesión</h1>
        <p class="lead">Inicie sesión para ingresar al sistema.</p>

        <div class="table-responsive">          
  <table class="table">
    <tbody>
      <tr>
          <td>
                <label for="txtNombre_Usuario">Nombre de usuario</label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre_Usuario" runat="server" Width="230px" class="form-control" required>
                </asp:TextBox>
            </td>
      </tr>
    
    
      <tr>
        <td>
                <label for="txtPassword">Contraseña</label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="230px" class="form-control"
                                TextMode="Password" required></asp:TextBox >
            </td>
      </tr>

          <tr>
              <td>
                <label for="recaptca">Digite el captcha</label>
            </td>
            <td colspan="2">
                <recaptcha:RecaptchaControl ID="recaptcha" runat="server"
                    PublicKey="6Le_KRYTAAAAALJclYpEzs5Lvp80tEfk_PPtPpxy"
                    PrivateKey="6Le_KRYTAAAAAJQCrXIqMJ9U6h47MprOtO7OC_Cx" />
            </td>
        </tr>

          <tr>
            <td colspan="2">
                <asp:Button class="btn btn-primary btn-lg" ID="btnSubmit" runat="server" Text="Ingresar"
                             />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>

    </tbody>
  </table>
  </div>
         
           
       
    </div>

    <div class="row">
        
    </div>

</asp:Content>
