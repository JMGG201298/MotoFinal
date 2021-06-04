var filaContenedor = document.querySelector("#fila-contenedor");
var principalCarta = document.querySelector("#principalCarta");

document.addEventListener("DOMContentLoaded", function (event) {
    principalCarta.addEventListener("click", presionarCartaCategoria);
    cargarCategorias();
});
function presionarCartaCategoria(e) {
    window.location.href = "Inicio/Tiendas?categoria=" + e.currentTarget.dataset.value;
}
function cargarCategorias() {
    fetch("../../Categoria/obtenerTodos")
        .then(function (res) {
            return res.json();
        })
        .then(function (miJson) {
            for (var i = 0; i < miJson.length; i++) {
                //Creación cartas categoria
                var columna = document.createElement("div");
                columna.dataset.value = miJson[i].idCategoria;
                columna.addEventListener("click", presionarCartaCategoria);

                columna.className = "col-2 col-md-1";
                var card = document.createElement("div");
                card.className = "card card-propio";
                var cardBody = document.createElement("div");
                cardBody.className = "card-body card-body-propio";
                var imagen = document.createElement("img");
                var arreglo = Array.from(miJson[i].imagen)
                var base64String = btoa(String.fromCharCode.apply(null, new Uint8Array(arreglo)));

                imagen.src = "data:image/jpg;base64," + base64String;
                imagen.className = "card-img-top";
                var titulo = document.createElement("p");
                titulo.innerHTML = miJson[i].nombre;
                

                cardBody.appendChild(titulo)
                card.appendChild(imagen);
                card.appendChild(cardBody);
                columna.appendChild(card);
                filaContenedor.appendChild(columna);
                //Creación cartas categoria
            }

        });
}
