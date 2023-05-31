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
$(document).ready(function () {

    $('#table_id').DataTable();

    fechaFactura.max = new Date().toLocaleDateString('fr-ca');
})

$(function () {
    var modalGenerico = $('#modalGenerico');
    $('button[data-toggle="modal"]').click(function (event) {
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

    var modalCliente = $('#modalBuscador');
    $('button[data-toggle="modal-recuperarCliente"]').click(function (event) {
        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
       
        $.get(decodeUrl).done(function (data) {
            modalCliente.html(data);
            modalCliente.find('.modal').modal('show');
        })
    })

});

var tablacliente;
function buscarCliente() {
    event.preventDefault();


    var parametro = document.querySelector("#parametro").value;
    if (parametro == "") {
        $("#parametro").focus();
        document.getElementById("parametro").style.borderColor = "red";
        setTimeout(() => {
            $("#parametro").css({ 'borderColor': '' });
        }, 3000);
    } else {
        tablacliente = $('#tbcliente').DataTable({
            "ajax": {

                "url": '/Cliente/GetCustomerByNombreCedula?parametro=' + parametro,
                "type": "GET",
                "datatype": "json"
            },
            "columns": [

                {
                    "data": "idCliente"
                },
                { "data": "identificacion" },
                { "data": "nombre" },
                { "data": "direccion" },
                { "data": "telefono" },
                { "data": "correo" },
                {
                    "data": "telefono", "render": function (data, type, row, meta) {
                        return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='llenarCliente(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i>Clic Aqui</button>"
                    },
                    orderable: false,
                    searchable: false,
                    "width": "90px"
                }

            ]
        });
    }
}

function llenarCliente(json) {

    $("#txtClienteId").val(json.idCliente);
    $("#txtclientedocumento").val(json.identificacion);
    $("#txtclientenombres").val(json.nombre);
    $("#txtclientedireccion").val(json.direccion);
    $("#txtclientetelefono").val(json.telefono);
    $('#modalBuscador').find('.modal').modal('hide');

}

////////
$(function () {

    var modalProducto = $('#modalBuscador');
    $('button[data-toggle="modal-recuperarProducto"]').click(function (event) {
        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);

        $.get(decodeUrl).done(function (data) {

            modalProducto.html(data);
            modalProducto.find('.modal').modal('show');
        })
    })

});

var tablaproducto;
function buscarProducto() {

    event.preventDefault();
    var parametroProducto = document.getElementById("parametroProducto").value;
    if (parametroProducto == "") {
        $("#parametroProducto").focus();
        document.getElementById("parametroProducto").style.borderColor = "red";
        setTimeout(() => {
            $("#parametroProducto").css({ 'borderColor': '' });
        }, 3000);
    } else {
        
        tablaproducto = $('#tbProducto').DataTable({
            "ajax": {
                "url": '/Producto/GetProductoByNombre?parametro=' + parametroProducto,
                "type": "GET",
                "datatype": "json"
            },


            "columns": [
                {
                    "data": "idProducto"

                },

                {
                    "data": "codigo"

                },
                {
                    "data": "nombre"
                },
                {
                    "data": "categoria"
                },
                {
                    "data": "precio"
                },
                {
                    "data": "descripcion", "render": function (data, type, row, meta) {
                        return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='llenarProducto(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i>Clic Aqui</button>"
                    },
                    orderable: false,
                    searchable: false,
                    "width": "90px"
                }

            ]
        });
    }
    
}

function llenarProducto(json) {

    $("#txtProductoId").val(json.idProducto);
    $("#txtproductocodigo").val(json.codigo);
    $("#txtproductonombre").val(json.nombre);
    $("#txtPrecioProducto").val(json.precio);
    $("#txtproductodescripcion").val(json.descripcion);
    $("#txtproductocantidad").val("0");
    $('#modalBuscador').find('.modal').modal('hide');

}


/////////////////////////

function genera_tabla() {
    var cantidad = document.getElementById("txtproductocantidad").value;
    var id = document.getElementById("txtProductoId").value;
    if (cantidad <= 0) {

        $("#txtproductocantidad").focus();
        document.getElementById("txtproductocantidad").style.borderColor = "red";
        setTimeout(() => {
            $("#txtproductocantidad").css({ 'borderColor': '' });
        }, 3000);
    } else {

        if (id <= 0) {

            $("#txtproductocodigo").focus();
            document.getElementById("txtproductocodigo").style.borderColor = "red";
            setTimeout(() => {
                $("#txtproductocodigo").css({ 'borderColor': '' });
            }, 3000);
        } else {
            var nombre = document.getElementById("txtproductonombre").value;
            var descripcion = document.getElementById("txtproductonombre").value;
            var precioUnidad = document.getElementById("txtPrecioProducto").value;
            var importeTotal = precioUnidad * cantidad;

            var tabla = document.getElementById("tbVenta");
            var tblBody = document.getElementById("tbodyVenta");
            var num = Math.random() * (500000 - 1) + 1;
            num = Math.round(num);
            var hilera = document.createElement("tr");
            hilera.className += "table-success";
            hilera.id += "eliminarFilaFactura" + num;


            var celdaIdProducto = document.createElement("td");
            var textoCeldaId = document.createTextNode(id);
            celdaIdProducto.appendChild(textoCeldaId);
            celdaIdProducto.hidden = true;
            hilera.appendChild(celdaIdProducto);


            var celdaCantidad = document.createElement("td");
            var textoCeldaCantidad = document.createTextNode(cantidad);
            celdaCantidad.appendChild(textoCeldaCantidad);
            hilera.appendChild(celdaCantidad);


            var celdaNombre = document.createElement("td");
            var textoCeldaNombre = document.createTextNode(nombre);
            celdaNombre.appendChild(textoCeldaNombre);
            hilera.appendChild(celdaNombre);

            var celdaDescripcion = document.createElement("td");
            var textoCeldaDescripcion = document.createTextNode(descripcion);
            celdaDescripcion.appendChild(textoCeldaDescripcion);
            hilera.appendChild(celdaDescripcion);

            var celdaPrecioUnidad = document.createElement("td");
            var textoPrecioUnidad = document.createTextNode(precioUnidad);
            celdaPrecioUnidad.appendChild(textoPrecioUnidad);
            hilera.appendChild(celdaPrecioUnidad);

            var celdaImporteTotal = document.createElement("td");
            var textoCeldaImporteTotal = document.createTextNode(importeTotal);
            celdaImporteTotal.appendChild(textoCeldaImporteTotal);
            hilera.appendChild(celdaImporteTotal);


            var unidadMedida= document.getElementById("txtproductoUnidadMedida").value;

            var celdaUnidadMedida = document.createElement("td");
            var textoUnidadMedida = document.createTextNode(unidadMedida);
            celdaUnidadMedida.appendChild(textoUnidadMedida);
            celdaUnidadMedida.hidden = true;
            hilera.appendChild(celdaUnidadMedida);


            var celda = document.createElement("td");
            var boton = document.createElement("button");
            boton.innerHTML = "X";
            boton.className += " btn btn-danger";




            boton.onclick = function () {


                var descontar = $("#eliminarFilaFactura" + num).find('td:eq(5)').text();
                var totalFactura = document.getElementById("txtsubtotal").value;
                $("#txtsubtotal").val(totalFactura - parseInt(descontar));
                $("#eliminarFilaFactura" + num).remove();
            }

            celda.appendChild(boton);
            hilera.appendChild(celda);
            tblBody.appendChild(hilera);
            tabla.appendChild(tblBody);

            var totalFactura = document.getElementById("txtsubtotal").value;
            var subtotal = 0;

            $("#tbVenta > tbody > tr").each(function (i, tr) {

                if (totalFactura == 0) {

                    subtotal = importeTotal;


                } else {

                    subtotal = parseInt($(tr).find('td:eq(5)').text()) + subtotal;
                }

            })
            $("#txtsubtotal").val(subtotal);
            $("#txttotalIva").val((subtotal * 12) / 100);
            $("#txtmontoFactura").val(subtotal + ((subtotal * 12) / 100));
            document.getElementById("btnFacturar").disabled = false;



        }
    }
       


 
        
        
      
 
}

$("#btnFacturar").on("click", function () {

    var fechaFactura = document.getElementById("fechaFactura").value;
    var idCliente = document.getElementById("txtClienteId").value;
    if (fechaFactura == "" || idCliente <= 0) {
        if (fechaFactura == "") {
            
            document.getElementById("fechaFactura").style.borderColor = "red";
            $("#fechaFactura").focus();
            setTimeout(() => {
              
                $("#fechaFactura").css({ 'borderColor': '' });
            }, 3000);
        } else {
            document.getElementById("txtclientedocumento").style.borderColor = "red";
            $("#txtclientedocum ento").focus();
            setTimeout(() => {
                $("#txtclientedocumento").css({ 'borderColor': '' });
            }, 3000);
        }
       
       


    } else {
        var DetalleVm2 = [];
        $("#tbVenta > tbody > tr").each(function (i, tr) {
            //suponiendo que el iva se calcula a cada producto:    
            var subtotal = $(tr).find('td:eq(5)').text();
            var ivaProducto = ((subtotal) * 12) / 100
            DetalleVm2.push(
                {
                    IdProducto: $(tr).find('td:eq(0)').text(),
                    Cantidad: $(tr).find('td:eq(1)').text(),
                    UnidadMedida: $(tr).find('td:eq(6)').text(),
                    Precio: $(tr).find('td:eq(4)').text(),
                    Iva: ivaProducto,
                    Subtotal: $(tr).find('td:eq(5)').text()
                }

            )
        })



        var FacturaCompletaRequestVm = {

            IdCaja: 1,
            IdEstablecimiento: 1,
            NumeroFactura: "",
            Fecha: document.getElementById("fechaFactura").value,
            IdCliente: document.getElementById("txtClienteId").value,
            Subtotal: document.getElementById("txtsubtotal").value,
            TotalIva: document.getElementById("txttotalIva").value,
            Total: document.getElementById("txtmontoFactura").value,
            Detalles: DetalleVm2
        }

        console.log(FacturaCompletaRequestVm);
        jQuery.ajax({
            url: '/Factura/CreateFactura/',
            type: "POST",
            data: JSON.stringify(FacturaCompletaRequestVm),
            dataType: "json",
            contentType: 'application/json',
            success: function (data) {
                if (data.respuesta) {
                    var url = "/Factura/Index";
                    window.location.href = url;
                }
            }

        })












    }

    

})
