<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido/Html/Index.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="MotoFinal.Contenido.Html.IniciarSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link  rel="stylesheet" href="../estilos/IniciarSesionCss.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="iniciarSesion-contenedor">
        <div class="form-group">
            <h4>Iniciar Sesión</h4>
            <label for="txtUsuario">Usuario o correo: </label>
            <input id="txtUsuario" type="text" class="form-control" />
        </div>
        <div class="form-group">
            <label for="txtContrasena">Contraseña: </label>
            <input id="txtContrasena" type="password" class="form-control" />
        </div>
        <asp:Button  type="button" class="btn btn-primary" ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" />
    </div>
</asp:Content>
