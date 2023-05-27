$('.btnsidebar').click(function () {


    $(this).toggleClass("click");
    $('.sidebar').toggleClass("show");

    $('#principal').toggleClass("principal1");
});
$('.sidebar ul li a').click(function () {
    var id = $(this).attr('id');
    $(' nav ul li ul.item-show-' + id).toggleClass("show");
    $('nav ul li #' + id + ' span').toggleClass("rotate");

});

$('nav ul li').click(function () {
    $(this).addClass("active").siblings().removeClass("active");
});

$(function () {


    var modalGenerico = $('#modalGenerico');
    $('button[data-toggle="modal"]'). click(function (event) {
        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            modalGenerico.html(data);
            modalGenerico.find('.modal').modal('show');
        })
    })

    modalGenerico.on('click', '[data-save="modal"]', function (event) {
            modalGenerico.find('.modal').modal('hide');
    })

});

$(function () {


    var modalCliente = $('#modalCliente');
    $('button[data-toggle="modal"]').click(function (event) {
        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            modalCliente.html(data);
            modalCliente.find('.modal').modal('show');
        })
    })


    var modalProducto = $('#modalProducto');
    $('button[data-toggle="modal"]').click(function (event) {
        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            modalProducto.html(data);
            modalProducto.find('.modal').modal('show');
        })
    })
  

});
var tablacliente;
var tablaproducto;
function buscarCliente() {
    event.preventDefault();
    var parametro = document.querySelector("#parametro").value;
  
    tablacliente = $('#tbcliente').DataTable({
        "ajax": {

            "url": '/Cliente/GetCustomerByNombreCedula?parametro=' + parametro,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

                { "data": "idCliente"
            },
            { "data": "identificacion" },
            { "data": "nombre" },
            { "data": "direccion" },
            { "data": "telefono" },
            { "data": "correo" },
            {
                "data": "telefono","render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='clienteSelect(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i>Clic Aqui</button>"
                },
                orderable: false,
                searchable: false,
                "width": "90px" }
           
        ]
    });
}
function buscarProducto() {
    event.preventDefault();
    var parametro = document.querySelector("#parametroooo").value;
    alert(parametro);
    tablaproducto = $('#tbProducto').DataTable({
        "ajax": {
            "url": '/Producto/GetProductoByNombre?parametro=' + parametro,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "idProducto", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='productoSelect(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                orderable: false,
                searchable: false,
                "width": "90px"
            },
            {
                "data": "idCategoria"
            },
            {
                "data": "codigo"

            },
            { "data": "descripcion" }

        ]
    });
}


$(document).ready(function () {

    $('#table_id').DataTable();

   
    
    
})


function clienteSelect(json) {

    document.getElementById("txtclientedocumento").value = json.identificacion;
    document.getElementById("txtclientenombres").value = json.nombre;
    document.getElementById("txtclientedireccion").value = json.direccion;
    document.getElementById("txtclientetelefono").value = json.telefono;
  
    var modalCliente = $('#modalCliente');
    modalCliente.find('.modal').modal('hide');
}




