using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

public class HubGameController : Hub
{

    public override Task OnConnected()
    {
        string currentConnectionId = Context.ConnectionId;
        PlayerManager.Current.AddPlayer(GameManager.Current.IdChecker.ToString(), currentConnectionId);

        return base.OnConnected();
    }

    public override Task OnDisconnected(bool stopCalled)
    {
        return base.OnDisconnected(stopCalled);
    }

    public async Task StartGame(string playerName, string color)
    {
        await Task.Run(() =>
        {
            string connectionId = Context.ConnectionId;
            var snakeId = GameManager.Current.IdChecker;
            Player player = PlayerManager.Current.PlayerList.FirstOrDefault(opt => opt.ConnectionId == connectionId);

            if (!player.IsCreated)
            {
                GameManager.Current.AddSnake(snakeId);
                GameManager.Current.GlobalGame.AddLeaderBoardPlayer(new LeaderBoard
                {
                    NickName = playerName,
                    CollectedCoints = 0,
                    SnakeId = snakeId
                });
                Clients.All.leaderBoard(GameManager.Current.GlobalGame.GetLeaderBoards());
                player.InGameName = playerName;
                player.SnakeSwitchedColor = color;
                player.SnakeId = snakeId;
                player.IsCreated = true;
                GameManager.Current.IdChecker++;
            }
        });
    }

    public async Task GetSnakeList()
    {
        await Task.Run(() => 
        {
            Clients.Caller.message(ConvertClass.ConvertValue(GameManager.Current.GlobalGame.SnakeList));
        });
    }

    public async Task GetPlayerList() 
    {
        await Task.Run(() =>
        {
            Clients.Caller.message(PlayerManager.Current.PlayerList);
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
            int playerIndex = PlayerManager.Current.GetPlayerIndex(currentConnectionId);
            int snakeId = PlayerManager.Current.PlayerList[playerIndex].SnakeId;
            int snakeIndex = GameManager.Current.GetSnakeIndex(snakeId);
            var currentSnake = GameManager.Current.GetSnakeObject(snakeId);
            if (snakeIndex >= 0)
            {
                GameManager.Current.ChangeSnakeMoveDirection(snakeIndex, newSnakeMoveDirection);
            }
        });
    }

    public async Task MoveSnakes()
    {
        await Task.Run(() =>
        {
            GameManager.Current.MovingSnakeMain();
        });
    }

    public async Task Ping()
    {
        await Task.Run(() =>
        {
            string currentConnectionId = Context.ConnectionId;
            Player player = PlayerManager.Current.PlayerList.FirstOrDefault(opt => opt.ConnectionId == currentConnectionId);
            if (player != null)
            {
                player.UpdatePing();
            }
        });
    }
}
