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
        double randomValue = RandomManager.GetRandomNumber();
        double randomHorizontal = Math.Floor(randomValue) / 100;
        double randomVertical = Math.Round(randomValue - Math.Floor(randomValue), 2);

        CoinOnBoard.HorizontalPosition = randomHorizontal;
        CoinOnBoard.VerticalPosition = randomVertical;
    }
}