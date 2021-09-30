 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Game
/// </summary>
public class Game
{
    public Game(string gameId = "0")
    {
        GameId = gameId;
        Board = new Board();
        SnakeList = new List<Snake>();
    }

    public string GameId { get; set; }

    public Board Board { get; set; }

    public List<Snake> SnakeList { get; set; }
}