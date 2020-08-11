﻿$(function () {
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
    });
});