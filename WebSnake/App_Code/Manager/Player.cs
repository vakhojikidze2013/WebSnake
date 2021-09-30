using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Player
/// </summary>
public class Player
{
    public Player(string gameId, string connectionId, int snakeId)
    {

        GameId = gameId;
        LastPing = -1;
        ConnectionId = connectionId;
        SnakeId = snakeId;
    }

    public int SnakeId { get; set; }

    public long LastPing { get; set; }

    public string GameId { get; set; }

    public string ConnectionId { get; set; }

}