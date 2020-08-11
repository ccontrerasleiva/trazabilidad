$(function () {
    $(document).ready(function () {
        //Limpiar modal
        function clearModal(formElement) {
            formElement.reset();
        }

        $(document).on('click', '.showModal', function () {
            var trainId = this.getAttribute("data-train-id");

            $.ajax({
                type: "GET",
                url: "/Trains/TrainSummaryModal/",
                data: { trainId: trainId },
                success: function (result) {
                    $(result.data).each(function (index, element) {
                        $("#trainForm").append(element);
                    });
                }
            });

            //if ($("#trainForm").children().length == 0)
            //    $("#modal-element-edit :submit").prop("disabled", true);
            //else
            //    $("#modal-element-edit :submit").prop("disabled", false);
        });

        //capturar id de tren en acordeon
        $('.ShowModalTrain').click(function (e) {
            //var trainId = this.getAttribute("data-train-id");
            //var TrenLocoId = this.getAttribute("data-Tren-Locomotora");
            
            //if (e.target.id == 'AgregarPareja') {
            //    var trainId = this.getAttribute("data-train-id");
            //}
            //if (e.target.id == 'ModificarLocom') {
                
            //    var LocomId = this.getAttribute("data-Locomotora");
            //}
            //if (e.target.id == 'ModificaTrip1') {
               
            //}
            //if (e.target.id == 'ModificaTrip2') {
               
            //}
            //if (e.target.id == 'BorrarTrenLoco') {
               
            //}
            //var trainId = this.getAttribute("data-train-id"); 

            $.ajax({
                type: "GET",
                url: "/Tren/AgregarParejaModal/",
                data: { trainId: trainId },
                success: function (result) {
                    $('#AgregarPareja').html(result.data);
                }
            });

            //if ($("#trainForm").children().length == 0)
            //    $("#modal-element-edit :submit").prop("disabled", true);
            //else
            //    $("#modal-element-edit :submit").prop("disabled", false);
        });

        //New Train
        $(document).on("hidden.bs.modal", "#modal-create",
            function () {
                clearModal(document.getElementById("modal-element-create"));
            }
        );

        $(document).on("hidden.bs.modal", "#modal-edit",
            function () {
                clearModal(document.getElementById("modal-element-edit"));
                $("#trainForm").empty();
                $("#accordion").empty();
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

        //UNTESTED
        $("#modal-edit").delegate("form", "submit", function () {
            var form = this;

            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#modal-edit").modal("hide");
                        clearModal(form);
                        var table = document.getElementById("summary");
                        //Find element and change its values
                        $(table).find('tbody').append(result.formatData);
                        toastr.success(result.message, result.source);
                    }
                    else {
                        toastr.error(result.message, result.source);
                    }
                }
            });

            return false;
        });


        //UNTESTED
        $("#modal-delete").delegate("form", "submit", function () {
            var form = this;

            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#modal-delete").modal("hide");
                        clearModal(form);
                        var table = document.getElementById("summary");
                        //Find element and change its values
                        $(table).find('tbody').append(result.formatData);
                        toastr.success(result.message, result.source);
                    }
                    else {
                        toastr.error(result.message, result.source);
                    }
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

    $("#addLocomotive").click(function () {
        $.ajax({
            type: "GET",
            url: '/Trains/AddLocomotive/',
            data: { size: $("#accordion").children().length / 2 },
            beforeSend: function () {
                $("#spinner").removeClass("hidden");
            },
            complete: function () {
                $("#spinner").addClass("hidden");
            },
            success: function (result) {
                $("#accordion").append(result.data);
            },
            error: function (result) {
                toastr.error("Ha ocurrido un error inesperado.", "Error");
                $("#modal-create").modal("hide");
            }
        });
    });
});

function deleteTrenLoc(productId) {
    $.ajax({
        type: 'GET',
        url: '/Tren/LoadTrenLocoModalxDel/', // The method name + paramater
        data: { id: productId },
        success: function (result) {
            //console.log(result);
            $('#locomotiveDelete').html(result.data); // This should be an empty div where you can inject your new html (the partial view)
        }
    });
};