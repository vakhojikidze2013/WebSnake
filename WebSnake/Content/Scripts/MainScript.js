
//hubContext.server.setMoveDirection("left")
var submitCheker = false;
$(".login-button").click(function () {
    let playerGameName = document.getElementById("in-game-name").value;
    let playerGameColor = document.getElementById("in-game-color").value;
    hubContext.server.startGame(String(playerGameName), String(playerGameColor));
    submitCheker = true;
    document.getElementById("in-game-name").value = "";
    document.getElementById("in-game-color").value = "";
    $(".input-name").remove();
});


$(document).ready(function() {
    document.addEventListener(KeyDown, function (events) {
        if (submitCheker) {
            if (events.key == KeyW) {
                hubContext.server.setMoveDirection(Up);
            }
    
            if (events.key == KeyS) {
                hubContext.server.setMoveDirection(Down);
            }
    
            if (events.key == KeyA) {
                hubContext.server.setMoveDirection(Left);
            }
    
            if (events.key == KeyD) {
                hubContext.server.setMoveDirection(Right);
            }
        }
    })
});