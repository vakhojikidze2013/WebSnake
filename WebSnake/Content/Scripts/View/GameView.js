const canvas = document.getElementById("main-canvas");
const ctx = canvas.getContext("2d");
canvas.width = window.innerWidth;
canvas.height = window.innerHeight;
//Window resize event listenner

var boardObjectSize = {
    x: window.innerHeight / 35,
    y: window.innerHeight / 35
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
            ctx.fillRect(currentSnakeXcordinate * window.window.innerWidth, currentSnakeYcordinate * window.innerHeight, boardObjectSize.x, boardObjectSize.y);

            for (var rawIndex = 0; rawIndex < currentSnakeObject.SnakeCordinatesList.length; rawIndex++) {
                var currentSnakeBodyObject = currentSnakeObject.SnakeCordinatesList[rawIndex];
                var currentSnakeBodyXcordinate = currentSnakeBodyObject.HorizontalPosition;
                var currentSnakeBodyYcordinate = currentSnakeBodyObject.VerticalPosition;
                ctx.fillStyle = "#000000";
                ctx.fillRect(currentSnakeBodyXcordinate * window.innerWidth, currentSnakeBodyYcordinate * window.innerHeight, boardObjectSize.x, boardObjectSize.y);
            }
        }

        var currentCoinObjectXcordinate = coinsInfo.HorizontalPosition;
        var currentCoinObjectYcordinate = coinsInfo.VerticalPosition;
        ctx.fillStyle = "#FFFF00";
        ctx.fillRect(currentCoinObjectXcordinate * window.innerWidth, currentCoinObjectYcordinate * window.innerHeight, boardObjectSize.x, boardObjectSize.y);
    }


}