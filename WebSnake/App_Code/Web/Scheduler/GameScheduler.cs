using Microsoft.AspNet.SignalR;
using System.Linq;
using System.Threading;



public class GameScheduler
{
    private static GameScheduler _instance;

    public static void StartScheduler()
    {
        if (_instance == null)
        {
            _instance = new GameScheduler();
            _instance.Start();
        }
    }

    private GameScheduler()
    {
    }

    private const int UpdateTimeInMiliSeconds = 50;

    private void Start()
    {
        // Create the timer callback delegate.
        TimerCallback cb = ProcessTimerEvent;

        // Create the timer. It is autostart, so creating the timer will start it.
        TimerEvent = new Timer(cb, string.Empty, 500, UpdateTimeInMiliSeconds);
    }

    private Timer TimerEvent;

    private void ProcessTimerEvent(object obj)
    {
        GameActions();
    }

    private void GameActions()
    {
        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext("HubGameController");
        GameManager.Current.MovingSnakeMain();

        for (int index = 0; index < GameManager.Current.GlobalGame.SnakeList.Count(); index++)
        {
            var currentSnake = GameManager.Current.GlobalGame.SnakeList[index];
            //SPEED CHANGER
            if (currentSnake.SnakeLength == SettingsGame.SnakeSpeedModifyFirstStage)
            {
                GameManager.Current.GlobalGame.SnakeList[index].SnakeMoveSpeed = MoveSpeed.Medium;
            }

            if (currentSnake.SnakeLength == SettingsGame.SnakeSppedModifySecondStage)
            {
                GameManager.Current.GlobalGame.SnakeList[index].SnakeMoveSpeed = MoveSpeed.Fast;
            }
            //END SPEED CHANGER
            var currentSnakeId = GameManager.Current.GlobalGame.SnakeList[index].SnakeId;
            bool checkDanger = GameManager.Current.CheckDanger(index);

            if (checkDanger == false)
            {
                if (GameManager.Current.CheckCoins(index) == true)
                {
                    GameManager.Current.GlobalGame.UpdateLeaderBoardPlayer(currentSnakeId, 1);
                    //GameManager.Current.GlobalGame.Board.GenerateNewCoin();
                    hubContext.Clients.All.leaderBoard(GameManager.Current.GlobalGame.GetLeaderBoards());
                }
            }
            else
            {
                GameManager.Current.GlobalGame.DeleteLeaderBoardPlayer(currentSnakeId);
                hubContext.Clients.All.leaderBoard(GameManager.Current.GlobalGame.GetLeaderBoards());
            }
        }
        hubContext.Clients.All.informationFromBack(ConvertClass.ConvertValue(GameManager.Current.GlobalGame.SnakeList),
                                                                             GameManager.Current.GlobalGame.Board.CoinsOnBoard);
    }
}
