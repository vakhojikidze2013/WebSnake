using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PlayerManager
/// </summary>
public class PlayerManager
{
    private PlayerManager()
    {
        PlayerList = new List<Player>();
    }

    private static PlayerManager _current = null;

    private static readonly object _threadLock = new object();

    ///this field create singelton pattern
    public static PlayerManager Current
    {
        get
        {
            if (_current == null)
            {
                lock (_threadLock)
                {
                    if (_current == null)
                    {
                        _current = new PlayerManager();
                    }
                }
            }
            return _current;
        }
    }

    public List<Player> PlayerList { get; set; }

    public void AddPlayer(string gameId, string connectionId, int snakeId)
    {
        PlayerList.Add(new Player(gameId, connectionId, snakeId));
    }

    public void RemovePlayer(string connectionId)
    {
        var playerIndex = GetPlayerIndex(connectionId);

        if (playerIndex >= 0)
        {
            PlayerList.RemoveAt(playerIndex);
        }
    }

    public int GetPlayerIndex(string connectionId)
    {
        return PlayerList.FindIndex(a => a.ConnectionId == connectionId);
    }


}