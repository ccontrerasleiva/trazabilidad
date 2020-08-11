///////////////////////////////////////////////VERSION 1 ///////////////////////////////////////////////////////////////////////////
var map;
var input;
var markers = [];
var registro = [];
var SinDuplicados = [];
var SinDuplicadosMarkers = [];
var IdTrainRepo = [];
var latlongRepo = [];
var marker;
var GPS;
var IdTrainOld;
var IdTrain;
var status;
var latlong;
var Tramos = [];
var Areas = [];
var RegistroLatLon = [];
var RegistroLatLonsinDup = [];
var DentroPols = [];
var infowindow;

var markertest = [];
var markertestsd = [];

var code;
var lats = [];
var longs = [];
var IdTrains = [];
var codes = [];
var statusA = [];
var SinDuplicadosIdTrains = [];
var SinDuplicadoslats = [];
var SinDuplicadoslongs = [];
var puntos = [];
var infoWindow = [];
var marca;
var data = [];

function initMap() {
    var bound = new google.maps.LatLngBounds();
    $(document).ready(function () {
        var styledMapType = new google.maps.StyledMapType(
            [
                {
                    "featureType": "all",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "administrative",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "administrative",
                    "elementType": "labels.text",
                    "stylers": [
                        {
                            "visibility": "on"
                        },
                        {
                            "lightness": "43"
                        },
                        {
                            "weight": "0.01"
                        },
                        {
                            "saturation": "-55"
                        }
                    ]
                },
                {
                    "featureType": "administrative",
                    "elementType": "labels.text.stroke",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "landscape",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "simplified"
                        },
                        {
                            "hue": "#0066ff"
                        },
                        {
                            "saturation": 74
                        },
                        {
                            "lightness": 100
                        }
                    ]
                },
                {
                    "featureType": "landscape",
                    "elementType": "labels.text",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "poi",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "simplified"
                        }
                    ]
                },
                {
                    "featureType": "poi",
                    "elementType": "labels.text",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "poi.attraction",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "poi.business",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "simplified"
                        }
                    ]
                },
                {
                    "featureType": "poi.business",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road",
                    "elementType": "labels.text",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "simplified"
                        },
                        {
                            "weight": 0.6
                        },
                        {
                            "saturation": -85
                        },
                        {
                            "lightness": 61
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "geometry",
                    "stylers": [
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.highway",
                    "elementType": "labels.text",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.arterial",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "road.local",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "on"
                        }
                    ]
                },
                {
                    "featureType": "road.local",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "transit",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "simplified"
                        }
                    ]
                },
                {
                    "featureType": "transit",
                    "elementType": "labels",
                    "stylers": [
                        {
                            "visibility": "off"
                        }
                    ]
                },
                {
                    "featureType": "water",
                    "elementType": "all",
                    "stylers": [
                        {
                            "visibility": "simplified"
                        },
                        {
                            "color": "#5f94ff"
                        },
                        {
                            "lightness": 26
                        },
                        {
                            "gamma": 5.86
                        }
                    ]
                }
            ],
            { name: 'Mapa Fepasa' }
        );

        map = new google.maps.Map(document.getElementById('map'),
            {
                center: { lat: -33.45496, lng: -70.679796 },
                zoom: 14,
                fullscreenControl: false,
                streetViewControl: false,
                mapTypeControlOptions: {
                    mapTypeIds: ['styled_map']
                }
            });

        map.mapTypes.set('styled_map', styledMapType);
        map.setMapTypeId('styled_map');

        ////Capa de Rutas fereas y Estaciones

        var viap0 = new google.maps.KmlLayer({
            url: 'https://fepasaweb.blob.core.windows.net/alistacion/lineas/LineaFFCC0.kml',
            suppressInfoWindows: true,
            preserveViewport: true
        });

        var viap1 = new google.maps.KmlLayer({
            url: 'https://fepasaweb.blob.core.windows.net/alistacion/lineas/LineaFFCC1.kml',
            suppressInfoWindows: true,
            preserveViewport: true
        });

        var viap2 = new google.maps.KmlLayer({
            url: 'https://fepasaweb.blob.core.windows.net/alistacion/lineas/LineaFFCC2.kml',
            suppressInfoWindows: true,
            preserveViewport: true
        });

        var viap3 = new google.maps.KmlLayer({
            url: 'https://fepasaweb.blob.core.windows.net/alistacion/lineas/LineaFFCC3.kml',
            suppressInfoWindows: true,
            preserveViewport: true
        });
        var viap4 = new google.maps.KmlLayer({
            url: 'https://fepasaweb.blob.core.windows.net/alistacion/lineas/LineaFFCC4.kml',
            suppressInfoWindows: true,
            preserveViewport: true
        });
        var viap5 = new google.maps.KmlLayer({
            url: 'https://fepasaweb.blob.core.windows.net/alistacion/lineas/LineaFFCC5.kml',
            suppressInfoWindows: true,
            preserveViewport: true
        });
        var Estacion = new google.maps.KmlLayer({
            url: 'https://fepasaweb.blob.core.windows.net/alistacion/estaciones/EstacionesFFCC.kml',
            suppressInfoWindows: true,
            preserveViewport: true
        });
        //viap0.setMap(map);
        //viap1.setMap(map);
        //viap2.setMap(map);
        //viap3.setMap(map);
        //viap4.setMap(map);
        //viap5.setMap(map);
        //Estacion.setMap(map);
        var nyLayer = new google.maps.KmlLayer(
            'http://www.searcharoo.net/SearchKml/newyork.kml',
            {
               
            });

        //habilita y deshabilita layers de estacion y vias
        $(document).on('change', 'input[type="checkbox"]', function (e) {
            if (this.id == "estacion") {
                if (this.checked) Estacion.setMap(map);
                else Estacion.setMap(null);
            }
            if (this.id == "vias") {
                if (this.checked) {
                    viap0.setMap(map);
                    viap1.setMap(map);
                    viap2.setMap(map);
                    viap3.setMap(map);
                    viap4.setMap(map);
                    viap5.setMap(map);
                }
                else {
                    viap0.setMap(null);
                    viap1.setMap(null);
                    viap2.setMap(null);
                    viap3.setMap(null);
                    viap4.setMap(null);
                    viap5.setMap(null);
                }
            }
        });

        //obtiene geocercas
        GetAreas(map);

        setInterval(function LoadGPSUpdate(gmap) {
            $.ajax({
                type: "GET",
                //url: '/TrainGPSLog/GetGPSUpdate',
                url: '/Gps/GetGPSUpdate',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    GPS = response.data;
                    IdTrains = [];
                    lats = [];
                    longs = [];
                    statusA = [];
                    $.each(GPS, function (index, gps) {
                        var myLatlng = new google.maps.LatLng(gps.Latitude, gps.Longitude);
                        RegistroLatLon.push(myLatlng);
                        latlong = gps.Latitude + ',' + gps.Longitude;
                        IdTrain = gps.TrainId;
                        code = gps.Code;
                        status = gps.Status;
                        var lat = gps.Latitude;
                        var long = gps.Longitude;

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        IdTrains.push(IdTrain);
                        lats.push(lat);
                        longs.push(long);
                        codes.push(code);
                        statusA.push(status);

                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        // elimina  marcador antiguo si se modifico su gps

                        //DeleteMarksOld(map);
                        //ReubicaMarks();
                        //marker = new google.maps.Marker({ position: myLatlng, map: gmap});
                        //markertest.push(marker);

                        ////añade marcador y verifica si se encuentra dentro de poligono

                        //for (var i = 0; i < Areas.length; i++) {
                        //    DentroPols[i] = google.maps.geometry.poly.containsLocation(myLatlng, Areas[i]) ?
                        //        'true' :
                        //        'false';

                        //    if (DentroPols[i] == "true") {
                        //        marker = new google.maps.Marker({ position: myLatlng, map: gmap });

                        //        infowindow = new google.maps.InfoWindow({
                        //            content: '(' + gps.TrainId + ')' + '(' + gps.Latitude + ',' + gps.Longitude + ')'
                        //        });

                        //        marker.addListener('click', function () {
                        //            infowindow.open(gmap, marker);
                        //        });

                        //    } else {
                        //        marker = new google.maps.Marker({
                        //            position: myLatlng,
                        //            map: gmap,
                        //            label: gps.TrainId,
                        //            animation: google.maps.Animation.BOUNCE
                        //        });

                        //        infowindow = new google.maps.InfoWindow({
                        //            content: '(' + gps.TrainId + ')' + '(' + gps.Latitude + ',' + gps.Longitude + ')'
                        //        });

                        //        marker.addListener('click', function () {
                        //            infowindow.open(gmap, marker);
                        //        });
                        //    }

                        //} //termina for
                        ////marker.setMap(map);
                        //markers.push(marker);
                        //registro.push(IdTrain);
                    });//fin de each

                    SinDuplicadoslongs = [];
                    SinDuplicadoslats = [];

                    $.each(IdTrains, function (i, el) {
                        if ($.inArray(el, SinDuplicadosIdTrains) === -1) SinDuplicadosIdTrains.push(el); /*arraysold.push(el)*/
                    });

                    $.each(lats, function (i, el) {
                        if ($.inArray(el, SinDuplicadoslats) === -1) SinDuplicadoslats.push(el);
                    });

                    $.each(longs, function (i, el) {
                        if ($.inArray(el, SinDuplicadoslongs) === -1) SinDuplicadoslongs.push(el);
                    });
                },
                failure: function (msg) {
                    alert(msg);
                }
            });

            //////////////////////////////////////////////////////////////TEST

            puntos = [];
            infoWindow = [];
            for (var ix = 0; ix < SinDuplicadosIdTrains.length; ix++) {
                puntos.push([[SinDuplicadosIdTrains[ix]], [SinDuplicadoslats[ix]], [SinDuplicadoslongs[ix]], [codes[ix]]]);
            }

            for (var i = 0; i < puntos.length; i++) {
                var box = new google.maps.InfoWindow({ content: '(' + puntos[i][3] + ')' + '(' + puntos[i][1] + ',' + puntos[i][2] + ')' }), marker, i;
                infoWindow.push(box);
            }

            deleteMarkers();

            //Place each marker on the map
            for (i = 0; i < puntos.length; i++) {
                var positionc = new google.maps.LatLng(puntos[i][1], puntos[i][2]);

                bound.extend(positionc);
                marca = new google.maps.Marker({
                    position: positionc,
                    map: gmap,
                    animation: google.maps.Animation.BOUNCE
                });

                // Add info window to marker
                google.maps.event.addListener(marca, 'click', (function (marca, i) {
                    return function () {
                        var box1 = infoWindow[i];
                        box1.open(gmap, marca);
                    }
                })(marca, i));

                marca.setMap(map);
                markers.push(marca);
            }
            ///////////////////////////////////////////////////////////////////

            registro = [];
            DentroPols = [];

            //cantidad de atrasos
            Asigna();
        }, 6000);
    });

    //buscador de servicios
    buscador();

    //json retorna feriados
    //var adate = [];
    //var adesc = [];
    //var ainfo = [];

    //var yourUrl = 'https://www.feriadosapp.com/api/holidays.json';
    //var json_obj = JSON.parse(Get(yourUrl));

    //$.each(json_obj, function (index, dat) {
    //    var fecha = dat.date;
    //    var Desc = dat.title;
    //    var info = dat.extra;
    //    adate.push(fecha);
    //    adesc.push(Desc);
    //    ainfo.push(info);
    //});
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//cantidad de atrasos  o al dia
function Asigna() {
    //var a = SinDuplicadosIdTrains.length;
    var SinSalir = 0;
    var Catrasado = 0;
    var Crelenti = 0;
    var Caldia = 0;
   
    for (var i = 0; i < statusA.length; i++) {
        if (statusA[i] === "0") {
            SinSalir++;
        } else if (statusA[i] === "5") {
            Catrasado++;
        } else if (statusA[i] === "4") {
            Crelenti++;
        } else if (statusA[i] === "3") {
            Caldia++;
        }
        
    }

    document.getElementById("cst").textContent = Caldia;
    document.getElementById("csr").textContent = Crelenti;
    document.getElementById("csa").textContent = Catrasado;
}
//Buscador de Servicios
function buscador() {
    var elemen = [];
    $(document).ready(function () {
        setInterval(function search() {
            var sel = document.getElementById("EstacionIds");
            $('#EstacionIds').children('option:not(:first)').remove();

            elemen = [];

            for (var i = 0; i < puntos.length; i++) {
                elemen.push([[puntos[i][0]], [puntos[i][3]]]);

                $("#EstacionIds").append($("<option />").val(elemen[i][0]).text(elemen[i][1]));
                $("#EstacionIds").trigger("chosen:updated");
            }

            $("#EstacionIds").change(function () {
                var selected = parseInt($("#EstacionIds option:selected").val());

                for (var i = 0; i < SinDuplicadosIdTrains.length; i++) {
                    if (selected === SinDuplicadosIdTrains[i]) {
                        map.setCenter(new google.maps.LatLng(SinDuplicadoslats[i], SinDuplicadoslongs[i]));
                        map.setZoom(14);
                    }
                }
            });
        }, 6000);
    });
}

// borra marcadores antiguos del mapa

function setMapOnAll(map) {
    //hace ciclo sobre los marcadores que hemos guardado en la variable markers
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

function deleteMarkers() {
    setMapOnAll(null);
    markers = [];
}

// recuperar datos mediante json de poligonos estaciones
function GetAreas(map) {
    $.ajax({
        type: "POST",
        url: '/Estacion/GetEstacionsMap',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var cordenadas = response.data;

            //Buscador de Estaciones

            //var input = document.getElementById('pac-input');
            //var searchBox = new google.maps.places.SearchBox(input);

            $.each(cordenadas, function (index, cor) {
                var bounds = new google.maps.LatLngBounds();
                var code = cor.Code;
                var desc = cor.Name;

                //procesamiento de coordenadas(obtener longitud y latitud)

                var area = cor.Area;
                var point = area.split(' ');
                var coord = point.map(function (data) {
                    var info = data.split(',');
                    var coords = {
                        lng: parseFloat(info[0]),
                        lat: parseFloat(info[1])
                    };
                    bounds.extend(coords);
                    return coords;
                });

                //Definimos una Variable de tipo array para almacenar los objetos new google.maps.LatLng
                var poligGMCoords = [];

                for (var i = 0; i < coord.length; i++) {
                    var coordenadas = coord[i];
                    poligGMCoords.push(coordenadas);
                }

                //Construyendo el póligono
                var poligono = new google.maps.Polygon({
                    paths: poligGMCoords,
                    strokeColor: '#FF0000',
                    strokeOpacity: 0.8,
                    strokeWeight: 2,
                    fillColor: '#FF0000',
                    fillOpacity: 0.35
                });
                poligono.setMap(map);

                Areas.push(poligono);

                //añade marcador al centro de poligono
                //var iconoMarca = new GIcon(G_DEFAULT_ICON);
                //iconoMarca.image = "/Content/img/markergreen.png";
                //var tamanoIcono = new GSize(17, 17);
                //iconoMarca.iconSize = tamanoIcono;

                    var marker = new google.maps.Marker({
                        position: bounds.getCenter(),
                        label: 'E'
                    });
                marker.setMap(map);

                var infowindow = new google.maps.InfoWindow({
                    content: '(' + code + ')' + desc
                });

                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(map, marker);
                });
            });
        },
        failure: function (msg) {
            alert(msg);
        }
    });
    //fin llamada ajax
}

//
//function Get(yourUrl) {
//    var Httpreq = new XMLHttpRequest(); // a new request
//    Httpreq.open("GET", yourUrl, false);
//    Httpreq.send(null);
//    return Httpreq.responseText;
//}