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

        //AGREGADO. JTC.
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

//AGREGADO. jtc.
function editServ(productId) {
    $.ajax({
        type: 'GET',
        url: '/Servicio/LoadServicioModal/', // The method name + paramater
        data: { id: productId },
        success: function (result) {
            //console.log(result);
            $('#ServicioEdit').html(result.data); // This should be an empty div where you can inject your new html (the partial view)
        }
    });
};

//AGREGADO. jtc.
function deleteServ(productId) {
    $.ajax({
        type: 'GET',
        url: '/Servicio/LoadServicioModalxDel/', // The method name + paramater
        data: { id: productId },
        success: function (result) {
            //console.log(result);
            $('#ServicioDelete').html(result.data); // This should be an empty div where you can inject your new html (the partial view)
        }
    });
};



