
//hubContext.server.setMoveDirection("left")
var submitCheker = false;
$(".login-button").click(function () {
    let playerGameName = document.getElementById("in-game-name").value;
    let playerGameColor = document.getElementById("in-game-color").value;
    hubContext.server.startGame(String(playerGameName), String(playerGameColor));
    console.log(playerGameName, playerGameColor)
    submitCheker = true;
    document.getElementById("in-game-name").value = "";
    document.getElementById("in-game-color").value = "";
    $(".input-name").remove();
});


document.addEventListener(KeyDown, function (events) {
    if (submitCheker) {
        if (events.key == KeyW) {
            console.log(Up);
            hubContext.server.setMoveDirection(Up);
        }

        if (events.key == KeyS) {
            console.log(Down);
            hubContext.server.setMoveDirection(Down);
        }

        if (events.key == KeyA) {
            console.log(Left);
            hubContext.server.setMoveDirection(Left);
        }

        if (events.key == KeyD) {
            console.log(Right);
            hubContext.server.setMoveDirection(Right);
        }
    }
})