var hubContext = $.connection.hubGameController;
var snakeInformation = undefined;
var coinsInfo = undefined;

hubContext.client.message = function (value1, value2) {
    console.log(value1, value2);
}

hubContext.client.informationFromBack = function (snakesInfo, coinInfo) {
    snakeInformation = snakesInfo;
    coinsInfo = coinInfo;
    console.log(coinsInfo);
}

$.connection.hub.start()
    .done(function () {
        console.log('Now connected, connection ID= ' + $.connection.hub.id);
    })

    .fail(function () {
        console.log('Could not Connect!');
    });