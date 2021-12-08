 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Game
{
    public Game(string gameId = "0")
    {
        GameId = gameId;
        Board = new Board();
        SnakeList = new List<Snake>();
        LeaderBoard = new List<LeaderBoard>();
    }

    public string GameId { get; set; }

    public Board Board { get; set; }

    private List<LeaderBoard> LeaderBoard { get; set; }

    public List<Snake> SnakeList { get; set; }

    public void AddLeaderBoardPlayer(LeaderBoard param)
    {
        LeaderBoard.Add(param);
    }

    public void DeleteLeaderBoardPlayer(int snakeId)
    {
        var index = LeaderBoard.FindIndex(opt => opt.SnakeId == snakeId);
        if (index >= 0)
        {
            LeaderBoard.RemoveAt(LeaderBoard.FindIndex(opt => opt.SnakeId == snakeId));
        }
    }

    public void UpdateLeaderBoardPlayer(int snakeId, int coin)
    {
        LeaderBoard leaderBoardObj = LeaderBoard.FirstOrDefault(opt => opt.SnakeId == snakeId);
        leaderBoardObj.CollectedCoints += coin;
    }

    public List<LeaderBoard> GetLeaderBoards ()
    {
        List<LeaderBoard> result = LeaderBoard.OrderByDescending(opt => opt.CollectedCoints).ToList();
        
        return result;
    }
}


public class LeaderBoard
{
    public string NickName { get; set; }

    public int CollectedCoints { get; set; }

    public int SnakeId { get; set; }
}