using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Player
/// </summary>
public class Player
{

    public Player(string gameId, string connectionId)
    {

        GameId = gameId;
        LastPing = -1;
        ConnectionId = connectionId;
        SnakeId = -1;
        InGameName = null;
        SnakeSwitchedColor = null;
        IsCreated = false;
    }

    public Player(string gameId, string connectionId, int snakeId)
    {

        GameId = gameId;
        LastPing = -1;
        ConnectionId = connectionId;
        SnakeId = snakeId;
        InGameName = null;
        SnakeSwitchedColor = null;
        IsCreated = false;
    }

    public Player(string gameId, string connectionId, int snakeId, string inGameName, string snakeSwitchedColor)
    {

        GameId = gameId;
        LastPing = -1;
        ConnectionId = connectionId;
        SnakeId = snakeId;
        InGameName = inGameName;
        SnakeSwitchedColor = snakeSwitchedColor;
        IsCreated = false;
    }


    public int SnakeId { get; set; }

    public long LastPing { get; set; }

    public string GameId { get; set; }

    public string ConnectionId { get; set; }

    public string InGameName { get; set; }

    public string SnakeSwitchedColor { get; set; }

    public bool IsCreated { get; set; } 

}