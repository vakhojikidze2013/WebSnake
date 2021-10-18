var hubContext = $.connection.hubGameController;
var snakeInformation = undefined;
var coinsInfo = undefined;

hubContext.client.message = function (value1, value2) {
    console.log(value1, value2);
}

hubContext.client.informationFromBack = function (snakesInfo, coinInfo) {
    snakeInformation = snakesInfo;
    coinsInfo = coinInfo;
}

$.connection.hub.start()
    .done(function () {
        hubContext.server.tt().then(x => consoleTest(x));
    })

    .fail(function () {
        console.log('Could not Connect!');
    });

function consoleTest(info) {
    console.log(info);
}