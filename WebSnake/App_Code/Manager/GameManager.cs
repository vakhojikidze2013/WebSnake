using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GameManager
/// </summary>
public class GameManager
{
    private GameManager()
    {
        GamesList = new List<Game>();
    }

    private static GameManager _current = null;

    private static readonly object _threadLock = new object();

    ///this field create singelton pattern
    public static GameManager Current
    {
        get
        {
            if (_current == null)
            {
                lock (_threadLock)
                {
                    if (_current == null)
                    {
                        _current = new GameManager();
                    }
                }
            }
            return _current;
        }
    }

    public List<Game> GamesList { get; set; }
}