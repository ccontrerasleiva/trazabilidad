$(function () {
    $(document).ready(function () {
        $("#summary").delegate("form", "submit", function () {
            var form = this;

            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        toastr.success(result.message, result.source);
                        var button = $(document.activeElement);
                        if (result.data)
                            button.removeClass("btn-default").addClass("btn-success");
                        else
                            button.removeClass("btn-success").addClass("btn-default");
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



