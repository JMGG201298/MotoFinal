<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido/Html/Index.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="MotoFinal.Contenido.Html.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../estilos/RegistrarseCss.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-xl">
        <div class="row">
            <div class="col-12 col-md-6">
                <div class="registrar-contenedor">
                    <div class="form-group">
                        <h5>Registrarse como Cliente</h5>
                        <label for="txtUsuarioCliente">Usuario o correo: </label>
                        <input id="txtUsuarioCliente" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtContrasenaCliente">Contraseña: </label>
                        <input id="txtContrasenaCliente" type="password" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtRepetirContrasenaCliente">Repetir contraseña: </label>
                        <input id="txtRepetirContrasenaCliente" type="password" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtNombreCliente">Nombre(s): </label>
                        <input id="txtNombreCliente" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtApellido1Cliente">Apellido 1: </label>
                        <input id="txtApellido1Cliente" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtApellido2Cliente">Apellido 2: </label>
                        <input id="txtApellido2Cliente" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="cbSexoCliente">Sexo: </label>
                        <select id="cbSexoCliente" class="form-control">
                            <option value="0" selected disabled>Seleccione una opción</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Femenino">Femenino</option>
                            <option value="Otros">Otros</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="txtFechaNacimientoCliente">Fecha de nacimiento: </label>
                        <input id="txtFechaNacimientoCliente" type="date" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtTelefonoCliente">Telefono: </label>
                        <input id="txtTelefonoCliente" type="tel" class="form-control" />
                    </div>
                    <asp:Button  type="button" class="btn btn-primary" ID="btnRegistrarseCliente" runat="server" Text="Registrarse" />
                </div>
            </div>
            <div class="col-12 col-md-6">
                <div class="registrar-contenedor">
                    <div class="form-group">
                        <h5>Registrarse como Repartidor</h5>
                        <label for="txtUsuarioRepartidor">Usuario o correo: </label>
                        <input id="txtUsuarioRepartidor" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtContrasenaRepartidor">Contraseña: </label>
                        <input id="txtContrasenaRepartidor" type="password" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtRepetirContrasenaRepartidor">Repetir contraseña: </label>
                        <input id="txtRepetirContrasenaRepartidor" type="password" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtNombreRepartidor">Nombre(s): </label>
                        <input id="txtNombreRepartidor" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtApellido1Repartidor">Apellido 1: </label>
                        <input id="txtApellido1Repartidor" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtApellido2Repartidor">Apellido 2: </label>
                        <input id="txtApellido2Repartidor" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="cbSexoRepartidor">Sexo: </label>
                        <select id="cbSexoRepartidor" class="form-control">
                            <option value="0" selected disabled>Seleccione una opción</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Femenino">Femenino</option>
                            <option value="Otros">Otros</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="txtFechaNacimientoRepartidor">Fecha de nacimiento: </label>
                        <input id="txtFechaNacimientoRepartidor" type="date" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtTelefonoRepartidor">Telefono: </label>
                        <input id="txtTelefonoRepartidor" type="tel" class="form-control" />
                    </div>
                    <asp:Button  type="button" class="btn btn-primary" ID="btnRegistrarRepartidor" runat="server" Text="Registrarse" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
