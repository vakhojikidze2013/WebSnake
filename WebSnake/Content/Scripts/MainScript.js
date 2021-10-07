
//hubContext.server.setMoveDirection("left")

document.addEventListener(KeyPress, function (events) {
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
})