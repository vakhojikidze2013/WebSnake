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
}