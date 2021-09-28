using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

public class HubGameController : Hub
{

    private readonly GameManager _gameManager = GameManager.Current;

    private readonly PlayerManager _playerManager = PlayerManager.Current;

    public override Task OnConnected()
    {
        return base.OnConnected();
    }

    public override Task OnDisconnected(bool stopCalled)
    {
        return base.OnDisconnected(stopCalled);
    }

}
