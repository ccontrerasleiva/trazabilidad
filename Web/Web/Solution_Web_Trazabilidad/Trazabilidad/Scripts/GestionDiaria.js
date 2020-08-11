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
            //debugger;
           
            //$("#modal-edit").on('hidden.bs.modal', function () {
            //    $(this).data('bs.modal', null);
            //});
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#modal-edit").modal("hide");
                        clearModal(form);
                        console.log(result);
                        //var table = document.getElementById("summary");
                        //$(table).find('tbody').append(result.data);
                        //toastr.success(result.message, result.source);
                    }
                    else {
                        toastr.error(result.message, result.source);
                    }
                }
            });
            
            return false;
        });

        $(document/*"#modal-edit"*/).delegate("#modal-editloc form", "submit", function () {
            var form = this;
            //debugger;

            //$("#modal-edit").on('hidden.bs.modal', function () {
            //    $(this).data('bs.modal', null);
            //});
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#modal-editloc").modal("hide");
                        clearModal(form);
                        console.log(result);
                        //var table = document.getElementById("summary");
                        //$(table).find('tbody').append(result.data);
                        //toastr.success(result.message, result.source);
                    }
                    else {
                        toastr.error(result.message, result.source);
                    }
                }
            });

            return false;
        });

        $(document/*"#modal-edit"*/).delegate("#modal-edittrip form", "submit", function () {
            var form = this;
            //debugger;

            //$("#modal-edit").on('hidden.bs.modal', function () {
            //    $(this).data('bs.modal', null);
            //});
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#modal-edittrip").modal("hide");
                        clearModal(form);
                        console.log(result);
                        //var table = document.getElementById("summary");
                        //$(table).find('tbody').append(result.data);
                        //toastr.success(result.message, result.source);
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
});

function CambioDeHora(productId) {
    $.ajax({
        type: 'GET',
        url: '/Tren/LoadTrenForTime/', // The method name + paramater
        data: {
            id: productId
        },
        success: function (result) {
            console.log(result);
            $('#TrenHora').html(result.data); // This should be an empty div where you can inject your new html (the partial view)
            $('#TrenHora #modal-edit').modal();
        }
    });
};

function SuprimTren(productId) {
    $.ajax({
        type: 'GET',
        url: '/Tren/LoadTren/', // The method name + paramater
        data: {
            id: productId
        },
        success: function (result) {
            console.log(result);
            $('#TrenSuprime').html(result.data); // This should be an empty div where you can inject your new html (the partial view)
            $('#TrenSuprime #modal-delete').modal();
        }
    });
};

function editloc(productId) {
    $.ajax({
        type: 'GET',
        url: '/Tren/LoadTrenModal/', // The method name + paramater
        data: {
            id: productId
        },
        success: function (result) {
            console.log(result);
            $('#locomotiveEdit').html(result.data); // This should be an empty div where you can inject your new html (the partial view)
            $('#locomotiveEdit #modal-edit').modal();
        }
    });
};

function DeleteTrenloc(productId) {
    $.ajax({
        type: 'GET',
        url: '/Tren/LoadTrenModalxDel/', // The method name + paramater
        data: {
            id: productId
        },
        success: function (result) {
            console.log(result);
            $('#locomotiveDelete').html(result.data); // This should be an empty div where you can inject your new html (the partial view)
            $('#locomotiveDelete #modal-delete').modal();
        }
    });
};

function ModificarLocom(productId) {
    $.ajax({
        type: 'GET',
        url: '/Tren/LoadTrenModalxEditLoc/', // The method name + paramater
        data: {
            id: productId
        },
        success: function (result) {
            console.log(result);
            $('#locomotiveEditLoc').html(result.data); // This should be an empty div where you can inject your new html (the partial view)
            $('#locomotiveEditLoc #modal-editloc').modal();
        }
    });
};

function ModificarTripulante(productId, TipoTrip) {
    $.ajax({
        type: 'GET',
        url: '/Tren/LoadTrenModalxEditTrip/', // The method name + paramater
        data: {
            id: productId,  TipoTrip
              
        },
        success: function (result) {
            console.log(result);
            $('#locomotiveEditTrip').html(result.data); // This should be an empty div where you can inject your new html (the partial view)
            $('#locomotiveEditTrip #modal-edittrip').modal();
        }
    });
};

