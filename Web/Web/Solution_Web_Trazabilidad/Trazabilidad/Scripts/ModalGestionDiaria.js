
//modificado.
$(function () {
    $(document).ready(function () {
        function clearModal(formElement) {
            formElement.reset();
        }

        //Clear modal when user hides it. Works for all modals!
        $(document).on("hidden.bs.modal", "#modal-create",
            function () {
                clearModal(document.getElementById("modal-element-create"));
            }
        );

        $(document).on("hidden.bs.modal", "#modal-edit",
            function () {
                clearModal(document.getElementById("modal-element-edit"));
            }
        );

        $(document).on("hidden.bs.modal", "#modal-delete",
            function () {
                clearModal(document.getElementById("modal-element-delete"));
            }
        );

        $("#modal-create").delegate("form", "submit", function () {
            var form = this;

            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#modal-create").modal("hide");
                        clearModal(form);
                        console.log(result);
                        var table = document.getElementById("summary");
                        $(table).find('tbody').append(result.data);
                        toastr.success(result.message, result.source);
                    }
                    else {
                        toastr.error(result.message, result.source);
                    }
                }
            });

            return false;
        });

        $(document/*"#modal-edit"*/).delegate("#modal-edit form", "submit", function () {
            var form = this;

            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        toastr.success(result.message, result.source);
                        //TODO: Mejorar
                        location.reload();
                    }
                    else {
                        toastr.error(result.message, result.source);
                    }
                },
                complete: function () {
                }
            });

            return false;
        });

        $(document/*"#modal-delete"*/).delegate("#modal-delete form", "submit", function () {
            var form = this;

            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        toastr.success(result.message, result.source);
                        //TODO: Mejorar
                        location.reload();
                    }
                    else {
                        toastr.error(result.message, result.source);
                    }
                },
                complete: function () {
                }
            });

            return false;
        });
    });
});


//Editar
var url_E;
var resultadoE;

//Eliminar
var url_D;
var resultadoD;

function Edit(productId, num_mantenedor) {
    if (num_mantenedor == '1') {
        url_E = '/Servicio/LoadServicioModal/';         //Mantenedor Servicio.
        resultadoE = '#ServicioEdit';
    }
    else if (num_mantenedor == '2') {
        url_E = '/Itinerario/LoadItinerarioModal/';     //Mantenedor Itinerario.
        resultadoE = '#ItinerarioEdit';
    }
    else if (num_mantenedor == '3') {
        url_E = '/Locomotora/LoadLocomotoraModal/';     //Mantenedor Locomotora.
        resultadoE = '#locomotiveEdit';
    }
    else if (num_mantenedor == '4') {
        url_E = '/Estacion/LoadEstacionModal/';        //Mantenedor Estación.
        resultadoE = '#estacionEdit';
    }
    else if (num_mantenedor == '5') {
        url_E = '/Tren/LoadTrenModal/';        //Gestion Diaria agregar pareja
        resultadoE = '#locomotiveEdit';
    }
    $.ajax({
        type: 'GET',
        url: url_E,
        data: { id: productId },
        success: function (result) {
            $(resultadoE).html(result.data); 
        }
    });
};

function Delete(productId, num_mantenedor) {
    if (num_mantenedor == '1') {
        url_D = '/Servicio/LoadServicioModalxDel/';          //Mantenedor Servicio.
        resultadoD = '#ServicioDelete';
    }
    else if (num_mantenedor == '2') {
        url_D = '/Itinerario/LoadItinerarioModalxDel/';      //Mantenedor Itinerario.
        resultadoD = '#ItinerarioDelete';
    }
    else if (num_mantenedor == '3') {
        url_D = '/Locomotora/LoadLocomotoraModalxDel/';      //Mantenedor Locomotora.
        resultadoD = '#locomotiveDelete';
    }
    else if (num_mantenedor == '4') {
        url_D = '/Estacion/LoadEstacionModalxDel/';          //Mantenedor Estación.
        resultadoD = '#estacionDelete';
    }
    $.ajax({
        type: 'GET',
        url: url_D, 
        data: { id: productId },
        success: function (result) {
            $(resultadoD).html(result.data); 
        }
    });
};
















