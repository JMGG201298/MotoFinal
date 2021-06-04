var listaSubcategorias = document.querySelectorAll(".lista-subcategorias");
var listaProductos = document.querySelectorAll(".product");
document.addEventListener("DOMContentLoaded", function (event) {
    cargarDirecciones();
    cargarClickProductos();
});
function cargarDirecciones() {
    var url = document.location.search;
    const urlParametros = new URLSearchParams(url);
    const idEstablecimiento = urlParametros.get("idEstablecimiento");

    
        for (var i = 0; i < listaSubcategorias.length; i++) {

            listaSubcategorias[i].addEventListener("click", function (e) {
                window.location.href = "Productos?idEstablecimiento=" + idEstablecimiento + "&subcategoria=" + e.currentTarget.dataset.value;
            });
        }
    
    
}
function cargarClickProductos() {
    for (var i = 0; i < listaProductos.length; i++) {
        listaProductos[i].addEventListener("click", function (e) {
            alert(e.currentTarget.dataset.value);
        });
    }
}
