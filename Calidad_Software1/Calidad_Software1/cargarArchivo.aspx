<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cargarArchivo.aspx.cs" Inherits="Calidad_Software1.cargarArchivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:FileUpload ID="cargarExcel" runat="server" />
    <input id="Submit" type="submit" value="Cargar" /><br />
    <asp:Label ID="lblCargar" runat="server" Text=""></asp:Label>
    
</asp:Content>
