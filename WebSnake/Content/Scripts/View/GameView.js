const canvas = document.getElementById("main-canvas");
const ctx = canvas.getContext("2d");
canvas.width = window.innerWidth;
canvas.height = window.innerHeight;
//Window resize event listenner

var boardObjectSize = {
    x: window.innerHeight / 35,
    y: window.innerWidth / 35
}

window.addEventListener(Resize, function () {
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;

});



animate();


function animate() {

    ctx.clearRect(0, 0, canvas.width, canvas.height);

    requestAnimationFrame(animate);
    if (snakeInformation != undefined) {

        for (var index = 0; index < snakeInformation.length; index++) {

            var currentSnakeObject = snakeInformation[index];
            var currentSnakeXcordinate = currentSnakeObject.HorizontalPosition;
            var currentSnakeYcordinate = currentSnakeObject.VerticalPosition;
            ctx.fillStyle = "#FF0000";
            ctx.fillRect(currentSnakeXcordinate * window.innerWidth + boardObjectSize.x / 2,
                         currentSnakeYcordinate * window.innerHeight + boardObjectSize.y / 2,
                          boardObjectSize.x, boardObjectSize.y);

            for (var rawIndex = 0; rawIndex < currentSnakeObject.SnakeCordinatesList.length; rawIndex++) {
                var currentSnakeBodyObject = currentSnakeObject.SnakeCordinatesList[rawIndex];
                var currentSnakeBodyXcordinate = currentSnakeBodyObject.HorizontalPosition;
                var currentSnakeBodyYcordinate = currentSnakeBodyObject.VerticalPosition;
                ctx.fillStyle = "#000000";
                ctx.fillRect(currentSnakeBodyXcordinate * window.innerWidth + boardObjectSize.x / 2,
                             currentSnakeBodyYcordinate * window.innerHeight + boardObjectSize.y / 2,
                             boardObjectSize.x, boardObjectSize.y);
            }
        }

        var currentCoinObjectXcordinate = coinsInfo.HorizontalPosition;
        var currentCoinObjectYcordinate = coinsInfo.VerticalPosition;
        ctx.fillStyle = "#FFFF00";
        ctx.fillRect(currentCoinObjectXcordinate * window.innerWidth + boardObjectSize.x / 2,
                     currentCoinObjectYcordinate * window.innerHeight + boardObjectSize.y / 2,
                     boardObjectSize.x, boardObjectSize.y);
    }


}