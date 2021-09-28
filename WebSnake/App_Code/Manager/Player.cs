using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Player
/// </summary>
public class Player
{
    public Player(string playerId, string gameId)
    {
        Id = playerId;
        GameId = gameId;
        LastPing = -1;
    }

    public string Id { get; set; }

    public long LastPing { get; set; }

    public string GameId { get; set; }

    public string ConnectionId { get; set; }
}