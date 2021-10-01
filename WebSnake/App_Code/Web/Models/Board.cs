using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Board
/// </summary>
public class Board
{
    public Board()
    {
        var HorizontalRandom = GetRandomNumber();
        var VerticalRandom = GetRandomNumber();
        CoinOnBoard = new Coin(HorizontalRandom, VerticalRandom);
    }

    public Coin CoinOnBoard { get; set; }

    public void GenerateNewCoin()
    {
        var newHorizontalRandomValue = GetRandomNumber();
        var newVerticalRandomValue = GetRandomNumber();

        CoinOnBoard.HorizontalPosition = newHorizontalRandomValue;
        CoinOnBoard.VerticalPosition = newVerticalRandomValue;
    }

    public double GetRandomNumber(double minimum = 0.0, double maximum = 1.0)
    {
        Random random = new Random();
        return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, 2);
    }
}