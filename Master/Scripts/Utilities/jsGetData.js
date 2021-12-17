

$(function () {

    // Cambio en Nit
    $("#inputNit").on('change', function () {       
        getClient();
    })

    function getClient() {
        var value = $("#inputNit").val();
        
        $.ajax({
            url: "/Venta/GetClientById/" + value,
            method: "GET",

            //data: '{value: ' + JSON.stringify(value) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8", 
            //data: { value: value },
            //dataType: "json",  
            success: function (data) {
                
                data = JSON.parse(data);

                console.log(data);

                $("#inputClientId").val("");  
                $("#inputNombre").val("");
                $("#inputDireccion").val("");

                $("#inputClientId").val(data.ClienteID);     

                $("#ClienteID").val(data.ClienteID);   
                

                $("#inputNombre").val(data.Nombre);
                $("#inputDireccion").val(data.Direccion);
            },
            error: function (err) {
                console.error(err);
            }
        })
    }
    // Fin ajax Cambio en Nit

    $("#inputProductoId").on('change', function () {
        getProduct();
    })

    function getProduct() {
        var valueProduct = $("#inputProductoId").val();
        
        $.ajax({
            url: "/Venta/GetProductById/" + valueProduct,
            method: "GET",            
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {

                response = JSON.parse(response);

                console.log(response);

                
                $("#inputNombreProducto").val("");
                $("#inputStock").val("");
                $("#inputPrecio").val("");
                $("#inputImporte").val("");

                //$("#inputCantidad").val("");
                                
                $("#inputNombreProducto").val(response.Nombre);
                $("#inputStock").val(response.Stock);
                $("#inputPrecio").val(response.Precio);
                //$("#inputImporte").val(importe);
                
             
            },
            error: function (err) {
                console.error(err);
            }
        })
    } // Fin producto

    $("#inputCantidad").on('change', function () {
        var cantidad = $("#inputCantidad").val();
        var precio = $("#inputPrecio").val();

        var importe = parseFloat(cantidad) * parseFloat(precio);

        $("#inputImporte").val("");
        $("#inputImporte").val(importe);
                
    })

});