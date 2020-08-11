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

        //$("#modal-create").delegate("form", "submit", function () {
        //    var form = this;

        //    $.ajax({
        //        url: this.action,
        //        type: this.method,
        //        data: $(this).serialize(),
        //        success: function (result) {
        //            if (result.success) {
        //                $("#modal-create").modal("hide");
        //                clearModal(form);
        //                console.log(result);
        //                var table = document.getElementById("summary");
        //                $(table).find('tbody').append(result.data);
        //                toastr.success(result.message, result.source);
        //            }
        //            else {
        //                toastr.error(result.message, result.source);
        //            }
        //        }
        //    });

        //    return false;
        //});
        $(document/*"#modal-create"*/).delegate("#modal-create form", "submit", function () {
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

        $(document/*"#modal-create"*/).delegate("#modal-create2 form", "submit", function () {
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

        $(document/*"#modal-edit"*/).delegate("#modal-editConfirma form","submit", function () {
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
        

        $(document/*"#modal-edit"*/).delegate("#modal-editTrip form", "submit", function () {
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

        $(document/*"#modal-edit"*/).delegate("#modal-editLoc form", "submit", function () {
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

        $(document/*"#modal-delete"*/).delegate("#modal-deleteTrenLoc form", "submit", function () {
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

//Crear
var url_C;
var resultadoC;

//Editar
var url_E;
var resultadoE;


//Eliminar
var url_D;
var resultadoD;

function Create(productId, num_mantenedor) {
    if (num_mantenedor == '1') {
        url_C = '/Tren/LoadTrenModalPlan/';         //Agregar Tren Locomotora.
        resultadoC = '#AgregarParejaCreate';
    } else if (num_mantenedor == '2') {
        url_C = '/Tren/LoadGestionTripAddPatioModal/';         //Gestion Tripulantes.
        resultadoC = '#ActividadPatioCreate';
    }

    $.ajax({
        type: 'GET',
        url: url_C,
        data: { id: productId },
        success: function (result) {
            $(resultadoC).html(result.data);
        }
    });
};

function Confirmar(productId, estado) {
    
        url_C = '/Tren/ConfirmaTren/';         //confirma
    resultadoC = '#ConfirmaTren';
    

    $.ajax({
        type: 'GET',
        url: '/Tren/ConfirmaTren/',
        data: { id: productId, estado },
        success: function (result) {
            $(resultadoC).html(result.data);
        }
    });
};

function Edit(productId, num_mantenedor) {
    if (num_mantenedor == '1') {
        url_E = '/Tren/LoadTrenModalPlanxHora/';         //Edita la hora reprogramada de Tren
        resultadoE = '#CambiaHoraTren';
    }
    else if (num_mantenedor == '2') {
        url_E = '/Tren/LoadTrenModalxEditLocPlan/';     //Editar Locomotora
        resultadoE = '#EditLoc';
        
    }
    else if (num_mantenedor == '3') {
        url_E = '/Tren/ConfirmaTren/';     //Mantenedor Locomotora.
        resultadoE = '#ConfirmaTren';
    }
    else if (num_mantenedor == '4') {
        url_E = '/Estacion/LoadEstacionModal/';         //Mantenedor Estación.
        resultadoE = '#estacionEdit';
    }
    else if (num_mantenedor == '5') {
        url_E = '/Tramo/LoadTramoModal/';              //Mantenedor Tramo.
        resultadoE = '#travelTimeEdit';
    }
    else if (num_mantenedor == '6') {
        url_E = '/Tiempo_Hapa/LoadTiempo_HapaModal/';              //Mantenedor Tramo.
        resultadoE = '#travelTimeHapaEdit';
    }
    else if (num_mantenedor == '10') {
        url_E = '/Tren/LoadTripulanteModal/';              //Mantenedor Tramo.
        resultadoE = '#ActividadEdit';
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

function EditTrip(productId, num_mantenedor, tipoTrip) {
    if (num_mantenedor == '1') {
        url_E = '/Tren/LoadTrenModalxEditTripPlan/';         //Edita Tripulantes
        resultadoE = '#EditTrip';
    }
    
    
        $.ajax({
            type: 'GET',
            url: url_E,
            data: { id: productId, tipoTrip },
            success: function (result) {
                $(resultadoE).html(result.data);
            }
        });
     
};


function Delete(productId, num_mantenedor) {
    if (num_mantenedor == '1') {
        url_D = '/Tren/LoadTrenModalDeletePlan/';          //Suprimir Tren
        resultadoD = '#SuprimirTren';
    }
    else if (num_mantenedor == '2') {
        url_D = '/Tren/LoadTrenModalxDelPlan/';      //Mantenedor Itinerario.
        resultadoD = '#DeleteTrenLocom';
    }
    else if (num_mantenedor == '3') {
        url_D = '/Locomotora/LoadLocomotoraModalxDel/';      //Mantenedor Locomotora.
        resultadoD = '#locomotiveDelete';
    }
    else if (num_mantenedor == '4') {
        url_D = '/Estacion/LoadEstacionModalxDel/';          //Mantenedor Estación.
        resultadoD = '#estacionDelete';
    }
    else if (num_mantenedor == '5') {
        url_D = '/Tramo/LoadTramoModalxDel/';            //Mantenedor Tramo.
        resultadoD = '#travelTimeDelete';
    }
    else if (num_mantenedor == '6') {
        url_D = '/Tiempo_Hapa/LoadTiempo_HapaModalxDel';            //Mantenedor Tramo.
        resultadoD = '#travelTimeHapaDelete';
    }

    
    $.ajax({
        type: 'GET',
        url: url_D,
        data: { id: productId},
        success: function (result) {
            $(resultadoD).html(result.data);
        }
    });
};
















