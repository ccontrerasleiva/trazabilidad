$(function () {
    loadDashboard();
    $("#mapa-tab").on('click', function (e) {
        loadMap();
    });
    
});


function loadMap() {
   
    var mapObj = new GMaps({
        el: '#map',
        lat: -32.9446035,
        lng: -70.2750233,
        zoom: 9
    });
    infoWindow = new google.maps.InfoWindow({});

    //Carga Estaciones de Andina
    mapObj.loadFromKML({
        url: 'https://fepasaweb.blob.core.windows.net/alistacion/Trazabilidad/ESTACIONTRAZABILIDA.kml',
        suppressInfoWindows: true,
        events: {
            click: function (point) {
                infoWindow.setContent(point.featureData.infoWindowHtml);
                infoWindow.setPosition(point.latLng);
                infoWindow.open(map.map);
            }
        }
    });

    var icon = {
        path: "M694.857143 0q105.714286 0 180.857143 53.428571t75.142857 129.428571l0 512q0 74.285714-71.714286 126.857143t-174.571429 55.428571l121.714286 115.428571q9.142857 8.571429 4.571429 20t-17.142857 11.428571l-603.428571 0q-12.571429 0-17.142857-11.428571t4.571429-20l121.714286-115.428571q-102.857143-2.857143-174.571429-55.428571t-71.714286-126.857143l0-512q0-76 75.142857-129.428571t180.857143-53.428571l365.714286 0zm-182.857143 768q45.714286 0 77.714286-32t32-77.714286-32-77.714286-77.714286-32-77.714286 32-32 77.714286 32 77.714286 77.714286 32zm329.142857-329.142857l0-292.571429-658.285714 0 0 292.571429 658.285714 0z",
        fillColor: '#000',
        fillOpacity: 1,
        strokeWeight: 0,
        scale: 0.03
    }
    function loadTrain() {
        $.when($.getJSON('../Armado/GetInfoLocomotoras')).done(function (d) {
            d.forEach(function (i, e) {
                $.when($.post('../Armado/GetInfoCarros', { locomotora: i.Locomotora.replace('LDR', 'LOC') })).done(function (e) {
                    var data = jQuery.parseJSON(e)
                
                    mapObj.addMarker({
                        lat: i.Latitud,
                        lng: i.Longitud,

                        icon: icon,
                        click: function () {
                            $('#modalTrainData').on('show.bs.modal', function () {
                                $("#modalTitulo").text('Locomotora ' + i.Locomotora)
                                $("#velocidad").text(i.Velocidad + 'Km/H')
                                $("#pk").text(i.Nom_Pk)
                                $("#carga").empty();

                                data.forEach(function (t) {

                                    html = '<tr>' +
                                        '<td style="text-align:left">' + t.Contenedor + '</td>' +
                                        '<td style="text-align:left">' + (t.Peso == '' ? '--' : t.Peso) + '</td>' +
                                        '</tr>';
                                    $("#carga").append(html);
                                });

                            });
                            $('#modalTrainData').modal('show');
                        }
                    });
                })
                
            });
        });
    }
    loadTrain();

    setInterval(loadTrain, 60000);
    
}

var groupBy = function (xs, key) {
    return xs.reduce(function (rv, x) {
        (rv[x[key]] = rv[x[key]] || []).push(x);
        return rv;
    }, {});
};

function loadDashboard() {

    $.when($.getJSON('../Armado/CantidadActivosforMap')).done(function (d) {
        contenedor = 0;
        carro = 0;
        dp = groupBy(d.ListadoActivos, 'TipoLector');
        op = groupBy(d.ResumenOperacion, 'ubicacionNormalizada')
        dpp = dp.Portico;
        dpt = dp.Taller;
        for (r in dpp) {
            contenedor += dpp[r].Contenedor;
            carro += dpp[r].Carro;
            $('.' + dpp[r].CodigoUbicacion + '.Contenedor').text(dpp[r].Contenedor);
            $('.' + dpp[r].CodigoUbicacion + '.Carro').text(dpp[r].Carro);
        }
        //Subtotales
        gb = groupBy(dpp, 'Sentido');
        $('.col1.subtotal.Contenedor').text(gb.Ida.reduce((a, b) => a + (b['Contenedor'] || 0), 0))
        $('.col2.subtotal.Contenedor').text(gb.Vuelta.reduce((a, b) => a + (b['Contenedor'] || 0), 0))

        $('.col1.subtotal.Carro').text(gb.Ida.reduce((a, b) => a + (b['Carro'] || 0), 0))
        $('.col2.subtotal.Carro').text(gb.Vuelta.reduce((a, b) => a + (b['Carro'] || 0), 0))

        //Total
        $('#contenedoresTotal').text(d.ListadoActivos.reduce((a, b) => a + (b['Contenedor'] || 0), 0));
        $('#carrosTotal').text(d.ListadoActivos.reduce((a, b) => a + (b['Carro'] || 0), 0));
        //Ruta
        $('#contenedoresRuta').text(dpp.reduce((a, b) => a + (b['Contenedor'] || 0), 0));
        $('#carrosRuta').text(dpp.reduce((a, b) => a + (b['Carro'] || 0), 0));
        //Taller
        $('#contenedoresTaller').text(dpt.reduce((a, b) => a + (b['Contenedor'] || 0), 0));
        $('#carrosTaller').text(dpt.reduce((a, b) => a + (b['Carro'] || 0), 0));

        rot = groupBy(d.ResumenOperacionTotal, 'ubicacionNormalizada');
        //fechas = rot.SALSAL.map(function (e) { return new Date(e.fechaOperacion).toLocaleDateString('es-CL') })
        //contenedoresSaladillo = rot.SALSAL.map(function (e) { return e.Contenedor })
        //debugger;
        /*contenedoresVentana = rot.VENVEN.map(function (e) { return e.Contenedor });

        var config = {
            type: 'line',
            data: {
                labels: fechas,
                datasets: [{
                    label: 'Contenedores Saladillo',
                    data: contenedoresSaladillo,
                    backgroundColor: 'rgb(255, 0, 0)',
                    borderColor: 'rgb(255, 0, 0)',
                    borderWidth: 1,
                    fill: false,
                },
                {
                    label: 'Contenedores Ventanas',
                    data: contenedoresVentana,
                    backgroundColor: 'rgb(0, 255, 0)',
                    borderColor: 'rgb(0, 255, 0)',
                    borderWidth: 1,
                    fill: false,
                }
                ]
            }
        };
        new Chart('tContainers', config);*/
        
        


        indOpSal = op.SALSAL !== undefined ? ((op.SALSAL[0].Contenedor) * 100 / 75) : 0;
        indOpVen = op.VENVEN !== undefined ? ((op.VENVEN[0].Contenedor) * 100 / 75) : 0;

        estadoSal = indOpSal >= 98 ? 'badge-soft-success' : (indOpSal > 80 && indOpSal < 98 ? 'badge-soft-warning' : 'badge-soft-danger')
        estadoSal = indOpSal >= 98 ? 'badge-soft-success' : (indOpSal > 80 && indOpSal < 98 ? 'badge-soft-warning' : 'badge-soft-danger')

        $("#saladilloOperaciones").addClass(estadoSal);
        $("#ventanaOperaciones").addClass(estadoSal);

        $("#operacionSalCarros").text(op.SALSAL !== undefined ? op.SALSAL[0].Carro : 'Sin Información');
        $("#operacionSalContenedores").text(op.SALSAL !== undefined ? op.SALSAL[0].Contenedor : 'Sin Información');
        $("#cumplimientoSal").text(indOpSal.toFixed(2) + '%');
        $("#operacionSalFecha").text(op.SALSAL !== undefined ? new Date(op.SALSAL[0].fechaOperacion).toLocaleDateString("es-CL") : '--');

        $("#operacionVenCarros").text(op.VENVEN !== undefined ? op.VENVEN[0].Carro : 'Sin Información');
        $("#operacionVenContenedores").text(op.VENVEN !== undefined ? op.VENVEN[0].Contenedor : 'Sin Información');
        $("#cumplimientoVen").text(indOpVen.toFixed(2) + '%');
        $("#operacionVenFecha").text(op.VENVEN !== undefined ? new Date(op.VENVEN[0].fechaOperacion).toLocaleDateString("es-CL") : '--');

    });
    
}


