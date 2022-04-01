using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for GameManager
/// </summary>
public class GameManager
{
    private GameManager()
    {
        //GamesList = new List<Game>();
        GlobalGame = new Game();
        IdChecker = 1;
    }

    private static GameManager _current = null;

    private static readonly object _threadLock = new object();

    ///this field create singelton pattern
    public static GameManager Current
    {
        get
        {
            if (_current == null)
            {
                lock (_threadLock)
                {
                    if (_current == null)
                    {
                        _current = new GameManager();
                    }
                }
            }
            return _current;
        }
    }

    //public List<Game> GamesList { get; set; }

    public int IdChecker { get; set; }

    public Game GlobalGame { get; set; }

    public void AddSnake(int snakeId)
    {
        double randomValue = RandomManager.GetRandomNumber();
        double randomHorizontal = Math.Floor(randomValue) / 100;
        double randomVertical = Math.Round(randomValue - Math.Floor(randomValue), SettingsGame.SnakeMoveValueRound);
        GlobalGame.SnakeList.Add(new Snake(randomHorizontal, randomVertical, snakeId));
    }

    public void DeleteSnake(int snakeId)
    {
        int snakeIndex = GetSnakeIndex(snakeId);
        if (snakeIndex >= 0)
        {
            GlobalGame.SnakeList.RemoveAt(snakeIndex);
        }
    }

    public int GetSnakeIndex(int snakeId)
    {
        return GlobalGame.SnakeList.FindIndex(a => a.SnakeId == snakeId);
    }

    public Snake GetSnakeObject(int snakeId)
    {
        return GlobalGame.SnakeList.FirstOrDefault(opt => opt.SnakeId == snakeId);
    }

    public void ChangeSnakeMoveDirection(int id, MoveDirection newDirection)
    {
        MoveDirection currentSnakeObjectMoveDirection = GlobalGame.SnakeList[id].SnakeMoveDirection;
        if (newDirection == MoveDirection.Down && currentSnakeObjectMoveDirection == MoveDirection.Up)
        {
            return;

        } 
        else if (newDirection == MoveDirection.Up && currentSnakeObjectMoveDirection == MoveDirection.Down)
        {
            return;
        }
        else if (newDirection == MoveDirection.Right && currentSnakeObjectMoveDirection == MoveDirection.Left)
        {
            return;
        }
        else if (newDirection == MoveDirection.Left && currentSnakeObjectMoveDirection == MoveDirection.Right)
        {
            return;
        }
        GlobalGame.SnakeList[id].SnakeMoveDirection = newDirection;
    }

    //This method makes head of snakes to move
    public void MovingSnakeMain()
    {
        List<Snake> snakeList = GlobalGame.SnakeList;

        for (int index = 0; index < GlobalGame.SnakeList.Count(); index++)
        {
            Snake currentSnakeObject = snakeList[index];
            if (currentSnakeObject.SnakeMoveDirection == MoveDirection.None)
            {
                continue;
            }

            if (currentSnakeObject.SnakeMoveDirection == MoveDirection.Up)
            {
                snakeList[index].VerticalPosition -= currentSnakeObject.SnakeMoveSpeed;
                snakeList[index].VerticalPosition = Math.Round(snakeList[index].VerticalPosition, SettingsGame.SnakeMoveValueRound);

                if (snakeList[index].VerticalPosition < 0.0)
                {
                    snakeList[index].VerticalPosition = Math.Round(1.0 - snakeList[index].VerticalPosition, SettingsGame.SnakeMoveValueRound);
                }
                MovingSnakeOther(index);
            }
            else if (currentSnakeObject.SnakeMoveDirection == MoveDirection.Down)
            {
                snakeList[index].VerticalPosition += currentSnakeObject.SnakeMoveSpeed;
                snakeList[index].VerticalPosition = Math.Round(snakeList[index].VerticalPosition, SettingsGame.SnakeMoveValueRound);

                if (snakeList[index].VerticalPosition > 1.0)
                {
                    snakeList[index].VerticalPosition = Math.Round(snakeList[index].VerticalPosition - 1.0, SettingsGame.SnakeMoveValueRound);
                }
                MovingSnakeOther(index);
            }
            else if (currentSnakeObject.SnakeMoveDirection == MoveDirection.Right)
            {
                snakeList[index].HorizontalPosition += currentSnakeObject.SnakeMoveSpeed;
                snakeList[index].HorizontalPosition = Math.Round(snakeList[index].HorizontalPosition, SettingsGame.SnakeMoveValueRound);

                if (snakeList[index].HorizontalPosition > 1.0)
                {
                    snakeList[index].HorizontalPosition = Math.Round(snakeList[index].HorizontalPosition - 1.0, SettingsGame.SnakeMoveValueRound);
                }
                MovingSnakeOther(index);
            }
            else if (currentSnakeObject.SnakeMoveDirection == MoveDirection.Left)
            {
                snakeList[index].HorizontalPosition -= currentSnakeObject.SnakeMoveSpeed;
                snakeList[index].HorizontalPosition = Math.Round(snakeList[index].HorizontalPosition, SettingsGame.SnakeMoveValueRound);

                if (snakeList[index].HorizontalPosition < 0.0)
                {
                    snakeList[index].HorizontalPosition = Math.Round(1.0 - snakeList[index].HorizontalPosition, SettingsGame.SnakeMoveValueRound);
                }
                MovingSnakeOther(index);


            }

        }
    }

    //This part of the code makes the snakes' bodies move
    private void MovingSnakeOther(int index)
    {
        List<Snake> snakeList = GlobalGame.SnakeList;
        Snake currentSnakeObject = snakeList[index];
        int snakePositionsLenght = currentSnakeObject.SnakeCordinateList.Count();

        for (int rawIndex = 0; rawIndex < currentSnakeObject.SnakeCordinateList.Count(); rawIndex++)
        {
            SnakeCordinates currentSnakeCordinate = currentSnakeObject.SnakeCordinateList[rawIndex];
            if (rawIndex == 0)
            {
                currentSnakeCordinate.HorizontalPosition = currentSnakeObject.PastHorizontalPosition;
                currentSnakeCordinate.VerticalPosition = currentSnakeObject.PastVerticalPosition;
                currentSnakeObject.ReChangeSnakePastCordinates();
            }
            else
            {
                SnakeCordinates pastCurrentSnakeCordinate = currentSnakeObject.SnakeCordinateList[rawIndex - 1];
                currentSnakeCordinate.HorizontalPosition = pastCurrentSnakeCordinate.PastHorizontalPosition;
                currentSnakeCordinate.VerticalPosition = pastCurrentSnakeCordinate.PastVerticalPosition;
                pastCurrentSnakeCordinate.PastHorizontalPosition = pastCurrentSnakeCordinate.HorizontalPosition;
                pastCurrentSnakeCordinate.PastVerticalPosition = pastCurrentSnakeCordinate.VerticalPosition;

                if (rawIndex + 1 == currentSnakeObject.SnakeCordinateList.Count() - 1)
                {
                    SnakeCordinates futureCurrentSnakeCordinate = currentSnakeObject.SnakeCordinateList[rawIndex + 1];
                    futureCurrentSnakeCordinate.HorizontalPosition = currentSnakeCordinate.PastHorizontalPosition;
                    futureCurrentSnakeCordinate.VerticalPosition = currentSnakeCordinate.PastVerticalPosition;
                    futureCurrentSnakeCordinate.PastHorizontalPosition = futureCurrentSnakeCordinate.HorizontalPosition;
                    futureCurrentSnakeCordinate.PastVerticalPosition = futureCurrentSnakeCordinate.VerticalPosition;
                    currentSnakeCordinate.PastHorizontalPosition = currentSnakeCordinate.HorizontalPosition;
                    currentSnakeCordinate.PastVerticalPosition = currentSnakeCordinate.VerticalPosition;
                    break;
                }
            }
        }
    }

    public bool CheckDanger(int snakeIndex)
    {
        List<Snake> snakeList = GlobalGame.SnakeList;
        SnakeCordinates checkingSnakeMainBodyPositions = new SnakeCordinates
        {
            HorizontalPosition = snakeList[snakeIndex].HorizontalPosition,
            VerticalPosition = snakeList[snakeIndex].VerticalPosition
        };

        for (int index = 0; index < snakeList.Count(); index++)
        {
            if (index == snakeIndex)
            {
                continue;
            }
            List<SnakeCordinates> currentSnake = snakeList[index].SnakeCordinateList;

            for (int rawIndex = 0; rawIndex < snakeList[index].SnakeCordinateList.Count(); rawIndex++)
            {
                double horizontalOtherSnakePosition = currentSnake[rawIndex].HorizontalPosition;
                double verticalOtherSnakePosition = currentSnake[rawIndex].VerticalPosition;
                double checkerSnakesHorizontalPosition = Math.Round(Math.Abs(checkingSnakeMainBodyPositions.HorizontalPosition - horizontalOtherSnakePosition), SettingsGame.SnakeMoveValueRound);
                double checkerSnakesVerticalPosition = Math.Round(Math.Abs(checkingSnakeMainBodyPositions.VerticalPosition - verticalOtherSnakePosition), SettingsGame.SnakeMoveValueRound);

                if (checkerSnakesVerticalPosition <= SettingsGame.CoinContactRadiusVertical && 
                    checkerSnakesHorizontalPosition <= SettingsGame.CoinContactRadiusHorizontal) 
                {
                    int snakeId = snakeList[snakeIndex].SnakeId;
                    DeleteSnake(snakeId);
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCoins(int snakeIndex)
    {
        List<Snake> snakeList = GlobalGame.SnakeList;
        SnakeCordinates snakeMainBodyPositions = new SnakeCordinates
        {
            HorizontalPosition = snakeList[snakeIndex].HorizontalPosition,
            VerticalPosition = snakeList[snakeIndex].VerticalPosition
        };

        for (var index = 0; index < GlobalGame.Board.CoinsOnBoard.Count; index++)
        {
            double snakeCoinsCheckerHorizotnal = Math.Round(Math.Abs(snakeMainBodyPositions.HorizontalPosition - GlobalGame.Board.CoinsOnBoard[index].HorizontalPosition), SettingsGame.SnakeMoveValueRound);
            double snakeCoinsCheckerVertical = Math.Round(Math.Abs(snakeMainBodyPositions.VerticalPosition - GlobalGame.Board.CoinsOnBoard[index].VerticalPosition), SettingsGame.SnakeMoveValueRound);
            //Check Coin pos and snake main body pos from Board class
            if (snakeCoinsCheckerVertical <= SettingsGame.CoinContactRadiusVertical && 
                snakeCoinsCheckerHorizotnal <= SettingsGame.CoinContactRadiusHorizontal)
            {
                //Add snake length
                snakeList[snakeIndex].AddSnakeNewStartPositions();
                snakeList[snakeIndex].SnakeLength++;
                GlobalGame.Board.GenerateNewCoin(index);
                return true;
            }
        }
        return false;
    }
}