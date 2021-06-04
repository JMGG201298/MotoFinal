var cbCategoria = document.querySelector("#cbCategoria");
document.addEventListener("DOMContentLoaded", function (event) {
    cargarCategorias();
});
function cargarCategorias() {
    fetch("../../Categoria/obtenerTodos")
        .then(function (res) {
            return res.json();
        })
        .then(function (miJson) {
            for (var i = 0; i < miJson.length; i++) {

                var opcion = document.createElement("option");
                opcion.value = miJson[i].idCategoria;
                opcion.innerText = miJson[i].nombre;
                cbCategoria.appendChild(opcion);
            }

        });
}