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


////Crear
//var url_C;
//var resultadoC;

//Editar
var url_E;
var resultadoE;

//Eliminar
var url_D;
var resultadoD;


//function Crear(productId, num_mantenedor) {
//    if (num_mantenedor == '1') {
//        url_C = '/Servicio/LoadServicioModalCreate/';                      //Mantenedor Servicio.
//        resultadoC = '#ServicioCreate';
//    }
//    $.ajax({
//        type: 'GET',
//        url: url_E,
//        data: { id: productId },
//        success: function (result) {
//            $(resultadoE).html(result.data);
//        }
//    });
//};


function Edit(productId, num_mantenedor) {
    if (num_mantenedor == '1') {
        url_E = '/Servicio/LoadServicioModal/';                      //Mantenedor Servicio.
        resultadoE = '#ServicioEdit';
    }
    else if (num_mantenedor == '2') {
        url_E = '/Itinerario/LoadItinerarioModal/';                  //Mantenedor Itinerario.
        resultadoE = '#ItinerarioEdit';
    }
    else if (num_mantenedor == '3') {
        url_E = '/Locomotora/LoadLocomotoraModal/';                  //Mantenedor Locomotora.
        resultadoE = '#locomotiveEdit';
    }
    else if (num_mantenedor == '4') {
        url_E = '/Estacion/LoadEstacionModal/';                      //Mantenedor Estación.
        resultadoE = '#estacionEdit';
    }
    else if (num_mantenedor == '5') {
        url_E = '/Tramo/LoadTramoModal/';                            //Mantenedor Tramo.
        resultadoE = '#travelTimeEdit';
    }
    else if (num_mantenedor == '6') {
        url_E = '/Tiempo_Hapa/LoadTiempo_HapaModal/';                //Mantenedor Tiempo Hapa.
        resultadoE = '#travelTimeHapaEdit';
    }
    else if (num_mantenedor == '7') {
        url_E = '/Festivo/LoadFestivoModal/';                        //Mantenedor Festivo.
        resultadoE = '#festivoEdit';
    }
    else if (num_mantenedor == '8') {
        url_E = '/TripulantePersona/LoadTripulantePersonaModal/';    //Mantenedor Tripulante Persona.
        resultadoE = '#TripulantePersonaEdit';
    }
    else if (num_mantenedor == '10') {
        url_E = '/Ausencia/LoadAusenciaModal/';                      //Mantenedor Ausencia.
        resultadoE = '#AusenciaEdit';
    }

   else if (num_mantenedor == '11') {
            url_E = '/Carro/LoadCarroModal/';                      //Mantenedor Carro.
            resultadoE = '#CarroEdit';
        
    }

    else if (num_mantenedor == '12') {
        url_E = '/Tag/LoadTagModal/';                      //Mantenedor Tag.
        resultadoE = '#TagEdit';

    }

    else if (num_mantenedor == '13') {
        url_E = '/Statu/LoadStatuModal/';                      //Mantenedor Statu.
        resultadoE = '#StatuEdit';

    }
    else if (num_mantenedor == '14') {
        url_E = '/Contenedor/LoadContenedorModal/';                      //Mantenedor Contenedor.
        resultadoE = '#ContenedorEdit';

    }
    else if (num_mantenedor == '15') {
        url_E = '/Cliente/LoadClienteModal/';                      //Mantenedor Cliente.
        resultadoE = '#ClienteEdit';
    }
    else if (num_mantenedor == '16') {
        url_E = '/Ruta/LoadRutaModal/';                      //Mantenedor Ruta.
        resultadoE = '#RutaEdit';
    }
    else if (num_mantenedor == '17') {
        url_E = '/Locomotora/LoadLocomotoraModal/';                      //Mantenedor Locomotora.
        resultadoE = '#LocomotoraEdit';
    }
    else if (num_mantenedor == '18') {
        url_E = '/Conductor/LoadConductorModal/';                      //Mantenedor Locomotora.
        resultadoE = '#ConductorEdit';
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
        url_D = '/Servicio/LoadServicioModalxDel/';                    //Mantenedor Servicio.
        resultadoD = '#ServicioDelete';
    }
    else if (num_mantenedor == '2') {
        url_D = '/Itinerario/LoadItinerarioModalxDel/';                //Mantenedor Itinerario.
        resultadoD = '#ItinerarioDelete';
    }
    else if (num_mantenedor == '3') {
        url_D = '/Locomotora/LoadLocomotoraModalxDel/';                //Mantenedor Locomotora.
        resultadoD = '#locomotiveDelete';
    }
    else if (num_mantenedor == '4') {
        url_D = '/Estacion/LoadEstacionModalxDel/';                   //Mantenedor Estación.
        resultadoD = '#estacionDelete';
    }
    else if (num_mantenedor == '5') {
        url_D = '/Tramo/LoadTramoModalxDel/';                         //Mantenedor Tramo.
        resultadoD = '#travelTimeDelete';
    }
    else if (num_mantenedor == '6') {
        url_D = '/Tiempo_Hapa/LoadTiempo_HapaModalxDel';              //Mantenedor Tiempo Hapa.
        resultadoD = '#travelTimeHapaDelete';
    }
    else if (num_mantenedor == '7') {
        url_D = '/Festivo/LoadFestivoModalxDel';                      //Mantenedor Festivo.
        resultadoD = '#festivoDelete';
    }
    else if (num_mantenedor == '8') {
        url_D = '/TripulantePersona/LoadTripulantePersonaxDel';       //Mantenedor Tiempo Persona.
        resultadoD = '#TripulantePersonaDelete';
    }
    else if (num_mantenedor == '9') {
        url_D = '/Ausencia/LoadAusenciaModalxDel';                    //Mantenedor Tiempo Persona.
        resultadoD = '#AusenciaDelete';
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













