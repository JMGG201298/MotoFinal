var listaCategorias = document.querySelector("#listaCategorias");
var filaTiendas = document.querySelector('#filaTiendas');
document.addEventListener("DOMContentLoaded", function (event) {
    cargarCategorias();
    //cargarTiendas();
    var listaCartasTienda = document.getElementsByClassName("cartaTienda");
    for (var i = 0; i < listaCartasTienda.length; i++) {
        listaCartasTienda[i].addEventListener("click", presionarTienda);
    }

});
//Este metodo nos permite cargar nuestras categoriass
function cargarCategorias() {
    fetch("../../Categoria/obtenerTodos")
        .then(function (res) {
            return res.json();
        })
        .then(function (miJson) {
            for (var i = 0; i < miJson.length; i++) {
                //Creacion fila de seleccion
                var fila = document.createElement("a");
                fila.dataset.value = miJson[i].idCategoria;
                fila.addEventListener("click", cargarSeleccion);
                fila.className="list-group-item list-group-item-action";
                fila.innerText = miJson[i].nombre;
                listaCategorias.appendChild(fila);
                //Creacion fila de seleccion
            }

        });
}
function cargarTiendas() {
    fetch("../../Establecimiento/obtenerTodos")
        .then(function (res) {
            return res.json();
        })
        .then(function (miJson) {
            //filaTiendas.innerHTML = "";
            for (var i = 0; i < miJson.length; i++) {
                //Creación cartas tienda
                var columna = document.createElement("div");
                columna.dataset.value = miJson[i].idEstablecimiento;
                columna.addEventListener("click", presionarTienda);
                var carta = document.createElement("div");
                var imagen = document.createElement("img");
                var body = document.createElement("div");
                var titulo = document.createElement("h6");
                titulo.innerText = miJson[i].nombre;

                columna.className = "col-6 col-md-4 col-lg-2";
                carta.className = "card";
                var arreglo = Array.from(miJson[i].fotoPerfil)
                var base64String = btoa(String.fromCharCode.apply(null, new Uint8Array(arreglo)));
                imagen.src = "data:image/jpg;base64," + base64String;
                imagen.className = "card-img-top";
                body.className = "card-body cuerpo-carta";
                titulo.className = "card-title titulo-carta";

                body.appendChild(titulo);
                carta.appendChild(imagen);
                carta.appendChild(body);
                columna.appendChild(carta);
                filaTiendas.appendChild(columna);
            }

        });
}
function presionarTienda(e) {
    window.location.href = "Productos?idEstablecimiento=" + e.currentTarget.dataset.value +"&subcategoria="+0;
}
function cargarSeleccion(e) {
    window.location.href = "Tiendas?categoria=" + e.currentTarget.dataset.value;
}