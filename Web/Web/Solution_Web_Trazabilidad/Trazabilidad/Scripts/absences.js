var date = new Date();
var d = date.getDate();
var m = date.getMonth();
var y = date.getFullYear();

$('#calendar').fullCalendar({
    locale: 'es',
    header: {
        left: 'prev,next today',
        center: 'title',
        right: 'month,agendaWeek',
    },
    events: function (start, end, timezone, callback) {
        $.getJSON('/Trains/GetTrainsForPlan/', function (arr) {
            var result = $(arr).map(function () {
                return {
                    title: this.title,
                    start: this.startDate,
                    end: this.endDate,
                    description: this.description,
                    allDay: true,
                    position: this.position
                };
            }).toArray();
            callback(result);
        });
    },
    eventClick: function (event, jsEvent, view) {
        $('#userName').html(event.title);
        $('#absReason').html(event.description);
        $('#jobTitle').html(event.position);
        $('#startDate').html(dateToString(event.start));
        $('#endDate').html(dateToString(event.end));
        $('#modalEvent').modal();
    },
    loading: function (bool) {
        //alert('events are being rendered'); // Add your script to show loading
    },
    eventAfterAllRender: function (view) {
        //alert('all events are rendered'); // remove your loading
    }
})

function dateToString(date) {
    var yy = date._d.getFullYear();
    var MM = date._d.getMonth();
    var dd = date._d.getDay();

    return dd + "/" + MM + "/" + yy;
}