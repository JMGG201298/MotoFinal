<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido/Html/Index.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="MotoFinal.Contenido.Html.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../estilos/InicioCss.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-xl">
        <div class="row">
            <div class="col-xl-12">
                <h5>Categorias</h5>
            </div>
        </div>
        <div class="container-xl conti">
            <div class="row" id="fila-contenedor">
                
            </div>
        </div>
    </div>
    <div class="container-xl">
        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="../imagenes/5936.jpg" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="../imagenes/5936.jpg" class="d-block w-100" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="../imagenes/5936.jpg" class="d-block w-100" alt="...">
                </div>
            </div>
                <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
        </div>
    </div>
    <script src="../Javascript/InicioJs.js"></script>
</asp:Content>
