using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

/// <summary>
/// Summary description for TimeScheduler
/// </summary>
public class TimeScheduler
{

    private readonly GameManager _gameManager = GameManager.Current;

    private readonly PlayerManager _playerManager = PlayerManager.Current;

    public TimeScheduler()
    {

    }

    public async Task DoWork()
    {
        await Task.Run(() =>
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext("HubGameController");
            _gameManager.MovingSnakeMain();
            
            for (int index = 0; index < _gameManager.GlobalGame.SnakeList.Count(); index++)
            {
                bool checkDanger = _gameManager.CheckDanger(index);
                if (checkDanger == false)
                {
                    _gameManager.CheckCoins(index);
                }
            }
            hubContext.Clients.All.message(_gameManager);
        });
    }
}