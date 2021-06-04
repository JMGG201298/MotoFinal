var columnaCategorias = document.querySelector(".columna-categorias");
var mapaGoogle = document.querySelector("#mapaGoogle");
var btnModalUbicacion = document.querySelector("#btnModalUbicacion");
var txtDireccion = document.querySelector("#txtDireccion");
var btnAceptar = document.querySelector("#btnAceptar");
var cbDirecciones = document.querySelector("#cbDirecciones");
var parrafoDireccion = document.querySelector("#parrafoDireccion");
var btnIniciarSesion = document.querySelector('#btnIniciarSesion');
var btnRegistrarse = document.querySelector('#btnRegistrarse');
var btnCarrito = document.querySelector('#btnCarrito');

/*Variables*/
var miMapa = null;
var marcador;



document.addEventListener("DOMContentLoaded", function (event) {
    cargarCategoriasPie();
    obtenerLocalStorage();

});
function cargarCategoriasPie() {
    fetch("../../Categoria/obtenerTodos")
        .then(function (res) {
            return res.json();
        })
        .then(function (miJson) {
            for (var i = 0; i < miJson.length; i++) {
                //Creación pie categoria
                var fila = document.createElement("div");
                fila.className = "row";
                var columna = document.createElement("div");
                columna.className = "col-3";
                var parrafo = document.createElement("p");
                parrafo.id = "parrafo-lista";
                var enlace = document.createElement("a");
                enlace.href = "#";
                parrafo.appendChild(enlace);
                enlace.innerHTML = miJson[i].nombre;

                columna.appendChild(parrafo);
                fila.appendChild(columna);

                columnaCategorias.appendChild(fila);
                //Creación pie categoria
            }

        });
}
btnModalUbicacion.addEventListener("click",function () {
    navigator.geolocation.getCurrentPosition(obtenerUbicacion);
});
function obtenerUbicacion(posicion) {
    if (!navigator.geolocation) {
        mapaGoogle.innerHTML = '<div class="alert alert-danger" role="alert">Este navegador no soporta la ubicación</div >';
    } else {
        var latitud = posicion.coords.latitude;
        var longitud = posicion.coords.longitude;
        if (miMapa == null) {
            miMapa = L.map('mapaGoogle').setView([latitud, longitud], 15);

            L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
                attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
                maxZoom: 18,
                id: 'mapbox/streets-v11',
                tileSize: 512,
                zoomOffset: -1,
                accessToken: 'pk.eyJ1IjoiczE3MTIwMjYzIiwiYSI6ImNrb2x1ZDYwOTAyZnYycG84eWprN2RnMmgifQ.HBYIbS9d0kqOTYoNXjdGqQ'
            }).addTo(miMapa);
            
        }
        
    }
}
function errorUbicacion() {'<p>No se pudo obtener unicación</p>';
}
function cargarMapaLeaft() {
    
}
function onMapClick(e) {
    alert("Presionaste en " + e.latlng);
}
txtDireccion.addEventListener("keyup", cargarDatosMapa);
function cargarDatosMapa() {
    if (txtDireccion.value.length > 3) {
        cbDirecciones.innerHTML = "";
        var direccion = txtDireccion.value;
        var otra = "https://api.mapbox.com/geocoding/v5/mapbox.places/" + direccion + ".json?types=address&proximity=-122.39738575285674,37.792514711136945&access_token=pk.eyJ1IjoiczE3MTIwMjYzIiwiYSI6ImNrb2x1ZDYwOTAyZnYycG84eWprN2RnMmgifQ.HBYIbS9d0kqOTYoNXjdGqQ";
        //var urlDirecciones = "https://api.mapbox.com/geocoding/v5/mapbox.places/" + direccion + ".json ? types = address & proximity=-122.39738575285674, 37.792514711136945 & access_token=pk.eyJ1IjoiczE3MTIwMjYzIiwiYSI6ImNrb2x1ZDYwOTAyZnYycG84eWprN2RnMmgifQ.HBYIbS9d0kqOTYoNXjdGqQ";
        fetch(otra)
            .then(function (res) {
                return res.json();
            }).then(function (miJson) {
                console.log(miJson.features[0].place_name);
                for (var i = 0; i < miJson.features.length; i++) {
                    var opcion = document.createElement("option");
                    opcion.setAttribute("value", miJson.features[i].center[1] + "," + miJson.features[i].center[0]);
                    opcion.innerHTML = miJson.features[i].place_name;
                    if (i == 0) {
                        opcion.setAttribute("selected", "selected");
                    }
                    cbDirecciones.appendChild(opcion);

                }
                seleccionarDireccion();
            });
    }
}
cbDirecciones.addEventListener("change", seleccionarDireccion);
function seleccionarDireccion() {
    
    var seleccion;
    if (cbDirecciones.selectedIndex == -1) {
        seleccion = cbDirecciones.options[0].value;
    } else {
        seleccion = cbDirecciones.options[cbDirecciones.selectedIndex].value;
    }
    var coordenadas = seleccion.split(",");
    if (marcador) {
        miMapa.removeLayer(marcador);
    }
    marcador = L.marker(coordenadas).addTo(miMapa);
    marcador.bindPopup("Ubicación seleccionada").openPopup();
}
btnAceptar.addEventListener("click", function (e) {
    guardarLocalStorage(cbDirecciones.options[cbDirecciones.selectedIndex].innerHTML);
    $('#modalUbicacion').modal('hide');
    obtenerLocalStorage();
});

function guardarLocalStorage(valor) {
    localStorage.setItem("mototaxUbicacion", valor);
}
function obtenerLocalStorage() {
    if (localStorage.getItem("mototaxUbicacion")) {
        parrafoDireccion.innerHTML = localStorage.getItem("mototaxUbicacion");
    }
}
btnModalUbicacion.addEventListener("click", function (e) {
    $('#modalUbicacion').modal('show');
    if (localStorage.getItem("mototaxUbicacion")) {
        txtDireccion.value = localStorage.getItem("mototaxUbicacion");
        cargarDatosMapa();
    }
});
btnIniciarSesion.addEventListener("click", function (e) {
    window.location.href = "/Inicio/IniciarSesion";
});
btnRegistrarse.addEventListener("click", function (e) {
    window.location.href = "/Inicio/Registrar";
});
btnCarrito.addEventListener("click", function (e) {
    $('#modalCarrito').modal('show');
});
    