const canvas = document.getElementById("main-canvas");
const ctx = canvas.getContext("2d");
canvas.width = 800;
canvas.height = 800;
//Window resize event listenner

var boardObjectSize = {
    x: canvas.height / 35,
    y: canvas.width / 35
}

//window.addEventListener(Resize, function () {
//    canvas.width = canvas.width;
//    canvas.height = canvas.height;

//});



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
            ctx.fillRect(currentSnakeXcordinate * canvas.width + boardObjectSize.x / 2,
                         currentSnakeYcordinate * canvas.height + boardObjectSize.y / 2,
                boardObjectSize.x, boardObjectSize.y);

            ctx.fillStyle = "#FFFFFF"
            ctx.font = "20px Arial";
            ctx.fillText(currentSnakeObject.NickName, currentSnakeXcordinate * canvas.width + boardObjectSize.x / 2 - 10, currentSnakeYcordinate * canvas.height + boardObjectSize.y / 2 - 10)

            for (var rawIndex = 0; rawIndex < currentSnakeObject.SnakeCordinatesList.length; rawIndex++) {
                var currentSnakeBodyObject = currentSnakeObject.SnakeCordinatesList[rawIndex];
                var currentSnakeBodyXcordinate = currentSnakeBodyObject.HorizontalPosition;
                var currentSnakeBodyYcordinate = currentSnakeBodyObject.VerticalPosition;
                ctx.fillStyle = currentSnakeObject.Color;
                ctx.fillRect(currentSnakeBodyXcordinate * canvas.width + boardObjectSize.x / 2,
                             currentSnakeBodyYcordinate * canvas.height + boardObjectSize.y / 2,
                             boardObjectSize.x, boardObjectSize.y);
            }
        }

        var currentCoinObjectXcordinate = coinsInfo.HorizontalPosition;
        var currentCoinObjectYcordinate = coinsInfo.VerticalPosition;
        ctx.fillStyle = "#FFFF00";
        ctx.fillRect(currentCoinObjectXcordinate * canvas.width + boardObjectSize.x / 2,
                     currentCoinObjectYcordinate * canvas.height + boardObjectSize.y / 2,
                     boardObjectSize.x, boardObjectSize.y);
    }


}