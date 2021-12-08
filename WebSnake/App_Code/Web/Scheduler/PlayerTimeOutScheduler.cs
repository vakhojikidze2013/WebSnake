using Microsoft.AspNet.SignalR;
using System;
using System.Linq;
using System.Threading;



public class PlayerTimeOutScheduler
{
    private static PlayerTimeOutScheduler _instance;

    public static void StartScheduler()
    {
        if (_instance == null)
        {
            _instance = new PlayerTimeOutScheduler();
            _instance.Start();
        }
    }

    private PlayerTimeOutScheduler()
    {
    }

    private const int UpdateTimeInMiliSeconds = 500;

    private void Start()
    {
        TimerCallback cb = ProcessTimerEvent;

        TimerEvent = new Timer(cb, string.Empty, 500, UpdateTimeInMiliSeconds);
    }

    private Timer TimerEvent;

    private void ProcessTimerEvent(object obj)
    {
        TimeOutActions();
    }

    private void TimeOutActions()
    {
        for (var index = 0; index <= PlayerManager.Current.PlayerList.Count - 1; index++)
        {
            var pingTime = PlayerManager.Current.PlayerList[index].LastPing;
            var currentPingTime = DateTime.Now.Ticks;
            if (pingTime != -1)
            {
                if (currentPingTime - pingTime >= 25000000)
                {
                    var snakeId = PlayerManager.Current.PlayerList[index].SnakeId;
                    var connectionId = PlayerManager.Current.PlayerList[index].ConnectionId;
                    GameManager.Current.DeleteSnake(snakeId);
                    GameManager.Current.GlobalGame.DeleteLeaderBoardPlayer(snakeId);
                    PlayerManager.Current.RemovePlayer(connectionId);
                }
            }
        }
    }
}
