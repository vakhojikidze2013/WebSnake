using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

public class HubGameController : Hub
{

    private readonly GameManager _gameManager = GameManager.Current;

    private readonly PlayerManager _playerManager = PlayerManager.Current;

    public override Task OnConnected()
    {
        var snakeId = _gameManager.IdChecker;
        string currentConnectionId = Context.ConnectionId;
        _gameManager.AddSnake(snakeId);
        _playerManager.AddPlayer(_gameManager.IdChecker.ToString(), 
                                 currentConnectionId, 
                                 snakeId);
        _gameManager.IdChecker++;
        return base.OnConnected();
    }

    public override Task OnDisconnected(bool stopCalled)
    {
        string currentConnectionId = Context.ConnectionId;
        int playerIndex = _playerManager.GetPlayerIndex(currentConnectionId);
        if (playerIndex >= 0)
        {
            int snakeId = _playerManager.PlayerList[playerIndex].SnakeId;
            _gameManager.DeleteSnake(snakeId);
            _playerManager.RemovePlayer(currentConnectionId);
        }
        return base.OnDisconnected(stopCalled);
    }

    public async Task GetSnakeList()
    {
        await Task.Run(() => 
        {
            Clients.Caller.message(ConvertClass.ConvertValue(_gameManager.GlobalGame.SnakeList));
        });
    }

    public async Task GetPlayerList() 
    {
        await Task.Run(() =>
        {
            Clients.Caller.message(_playerManager.PlayerList);
        });
    }

    public async Task SetMoveDirection(string moveDirection)
    {
        await Task.Run(() =>
        {
            MoveDirection newSnakeMoveDirection;

            if (moveDirection == "left")
            {
                newSnakeMoveDirection = MoveDirection.Left;
            }
            else if (moveDirection == "right")
            {
                newSnakeMoveDirection = MoveDirection.Right;
            }
            else if (moveDirection == "up")
            {
                newSnakeMoveDirection = MoveDirection.Up;
            }
            else if (moveDirection == "down")
            {
                newSnakeMoveDirection = MoveDirection.Down;
            } 
            else
            {
                return;
            }

            string currentConnectionId = Context.ConnectionId;
            int playerIndex = _playerManager.GetPlayerIndex(currentConnectionId);
            int snakeId = _playerManager.PlayerList[playerIndex].SnakeId;
            int snakeIndex = _gameManager.GetSnakeIndex(snakeId);
            if (snakeIndex >= 0)
            {
                _gameManager.ChangeSnakeMoveDirection(snakeIndex, newSnakeMoveDirection);
            }
        });
    }

    public async Task MoveSnakes()
    {
        await Task.Run(() =>
        {
            _gameManager.MovingSnakeMain();
        });
    }

    public int Tt()
    {
        return 12;
    }
}
