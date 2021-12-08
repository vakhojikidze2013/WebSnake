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
        CoinsOnBoard = new List<Coin>();
        GenerateStartCoins();
    }

    public List<Coin> CoinsOnBoard { get; set; }

    public void GenerateNewCoin(int index)
    {
        double randomValue = RandomManager.GetRandomNumber();
        double randomHorizontal = Math.Floor(randomValue) / 100;
        double randomVertical = Math.Round(randomValue - Math.Floor(randomValue), 2);

        CoinsOnBoard[index].HorizontalPosition = randomHorizontal;
        CoinsOnBoard[index].VerticalPosition = randomVertical;
    }

    public void GenerateStartCoins()
    {
        CoinsOnBoard.Add(new Coin(SettingsGame.FirstCoinHorizontal, SettingsGame.FirstCoinVertical));
        CoinsOnBoard.Add(new Coin(SettingsGame.SecondCoinHorizontal, SettingsGame.SecondCoinVerctical));
        CoinsOnBoard.Add(new Coin(SettingsGame.ThirdCoinHorizontal, SettingsGame.ThirdCoinVerctical));
        CoinsOnBoard.Add(new Coin(SettingsGame.FourCoinHorizontal, SettingsGame.FourCoinVertical));
    }
}