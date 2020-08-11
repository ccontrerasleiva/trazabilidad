$.ajax({
    type: "POST",
    url: '/Tripulante/GetTripulantePersona',
    data: "{}",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (response) {
        var Personas = response.data;

        //Buscador de Estaciones

        //var input = document.getElementById('pac-input');
        //var searchBox = new google.maps.places.SearchBox(input);

       

        });
    }
    failure: function (msg) {
        alert(msg);
    }
});



function buscador() {
    var elemen = [];
    $(document).ready(function () {
        setInterval(function search() {
            var sel = document.getElementById("tripulantes");
            $('#tripulantes').children('option:not(:first)').remove();

            elemen = [];

            for (var i = 0; i < puntos.length; i++) {
                elemen.push([[puntos[i][0]], [puntos[i][3]]]);

                $("#tripulantes").append($("<option />").val(elemen[i][0]).text(elemen[i][1]));
                $("#tripulantes").trigger("chosen:updated");
            }

            $("#tripulantes").change(function () {
                var selected = parseInt($("#tripulantes option:selected").val());

                for (var i = 0; i < SinDuplicadosIdTrains.length; i++) {
                    if (selected === SinDuplicadosIdTrains[i]) {
                        map.setCenter(new google.maps.LatLng(SinDuplicadoslats[i], SinDuplicadoslongs[i]));
                        map.setZoom(14);
                    }
                }
            });
        }, 3000);
    });
}