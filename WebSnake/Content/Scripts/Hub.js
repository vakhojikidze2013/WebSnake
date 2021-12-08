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

hubContext.client.leaderBoard = function (info) {
    drawLeaderBoard(info);
}

$.connection.hub.start()
    .done(function () {
        setInterval(() => {
            hubContext.server.ping();
        }, 500);
    })

    .fail(function () {
        console.log('Could not Connect!');
    });

