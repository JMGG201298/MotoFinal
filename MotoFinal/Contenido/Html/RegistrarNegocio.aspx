<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido/Html/Index.Master" AutoEventWireup="true" CodeBehind="RegistrarNegocio.aspx.cs" Inherits="MotoFinal.Contenido.Html.RegistrarNegocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../estilos/RegistrarNegocioCss.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="registrar-tienda-contenedor">
        <div class="form-group">
            <label for="txtNombreNegocio">Nombre del negocio:</label>
            <asp:TextBox type="text" class="form-control" id="txtNombreNegocio" runat="server"></asp:TextBox>
            <small id="nombreNegocioHelp" class="form-text text-muted">Este el nombre por el que serás indentficado en la página</small>
        </div>
        <div class="form-group">
            <label for="cbCategoria">Categorias: </label>
            <asp:ListBox runat="server" multiple id="cbCategoria" class="form-control">
                
            </asp:ListBox>
            <small id="cbCategoriahHelp">Mantenga presionado shift para seleccionar mas de una opción</small>
        </div>
        <div class="form-group">
            <label for="txtUsuario">Usuario: </label>
            <asp:TextBox runat="server" id="txtUsuario" type="text" class="form-control" />
            <small id="txtUsuarioHelp">Elija un nombre de usuario</small>
        </div>
        <div class="form-group">
            <label for="txtCorreo">Correo: </label>
            <asp:TextBox runat="server" id="txtCorreo" type="email" class="form-control" />
            <small id="txtCorreoHelp">Ingrese un correo</small>
        </div>
        <div class="form-group">
            <label for="txtContrasena">Contraseña: </label>
            <asp:TextBox runat="server" id="txtContrasena" type="password" class="form-control" />
            <small id="txtContrasenaHelp">Elija una contraseña segura</small>
        </div>
        <div class="form-group">
            <label for="txtRepetirContrasena">Repetir Contraseña: </label>
            <asp:TextBox runat="server" id="txtRepetirContrasena" type="password" class="form-control" />
            <small id="txtRepetirContrasenaHelp">Vuelva a escribir la contraseña</small>
        </div>
         <div class="form-group">
            <label for="txtDireccionWeb">Dirección web: </label>
            <asp:TextBox runat="server" id="txtDireccionWeb" type="text" class="form-control" />
            <small id="txtDireccionWebHelp"></small>
        </div>
        <div class="form-group">
            <label for="txtFotoPerfil">Selecciona una foto de perfil</label>
            <asp:FileUpload accept=".jpg" runat="server" class="form-control-file" id="txtFotoPerfil"/>
            <small id="txtFotoPerfilHelp">Está foto es la miniatura de tu negocio</small>
        </div>
        <div class="form-group">
            <label for="txtFotoPortada">Selecciona una foto de portada</label>
            <asp:FileUpload accept=".jpg" class="form-control-file" id="txtFotoPortada" runat="server"/>
            <small id="txtFotoPerfiPortada">Está foto se mostrara cuando entren al perfil de tu tienda</small>
        </div>
        <div class="form-group">
            <h5>Datos del lugar</h5>
            <label for="txtCalle">Calle:</label>
            <asp:TextBox runat="server" type="text" class="form-control" id="txtCalle" ></asp:TextBox> 
        </div>
        <div class="form-group">
            <label for="txtEntreCalle">Entre Calle:</label>
            <asp:TextBox runat="server" type="text" class="form-control" id="txtEntreCalle"></asp:TextBox> 
        </div>
        <div class="form-group">
            <label for="txtYCalle">Y Calle:</label>
            <asp:TextBox runat="server" type="text" class="form-control" id="txtYCalle"></asp:TextBox> 
        </div>
        <div class="form-group">
            <label for="cbPais">País: </label>
            <select id="cbPais" class="form-control">
                <option value="1" selected>México</option>
                <option value="2">Argentina</option>
                <option value="3">Colombia</option>
                <option value="4">Costa Rica</option>
                <option value="5">Perú</option>
                <option value="6">Honduras</option>
                <option value="7">Brasil</option>
                <option value="8">Estados Unidos</option>
                <option value="9">Canada</option>
            </select>
        </div>
        <div class="form-group form-check">
            <input type="checkbox" class="form-check-input" id="txtTerminos">
            <label class="form-check-label" for="txtTerminos">Aceptó <a href="#">términos y condiciones</a> del servicio</label>
        </div>
        <asp:Button disabled type="button" class="btn btn-primary" ID="btnRegistrarNegocio" runat="server" Text="Registrar Negocio" OnClick="btnRegistrarNegocio_Click" />
    </div>
</asp:Content>
