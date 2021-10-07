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
        CoinOnBoard = new Coin();
        GenerateNewCoin();
    }

    public Coin CoinOnBoard { get; set; }

    public void GenerateNewCoin()
    {
        var randomValue = GetRandomNumber();
        var randomHorizontal = Math.Floor(randomValue) / 100;
        var randomVertical = Math.Round(randomValue - Math.Floor(randomValue), 2);

        CoinOnBoard.HorizontalPosition = randomHorizontal;
        CoinOnBoard.VerticalPosition = randomVertical;
    }

    public double GetRandomNumber(double minimum = 10.0, double maximum = 99.0)
    {
        Random random = new Random();
        return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, 2);
    }
}