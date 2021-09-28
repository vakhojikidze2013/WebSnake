var hubContext = $.connection.hubGameController;

$.connection.hub.start()
    .done(function () {
        console.log('Now connected, connection ID= ' + $.connection.hub.id);
    })

    .fail(function () {
        console.log('Could not Connect!');
    });