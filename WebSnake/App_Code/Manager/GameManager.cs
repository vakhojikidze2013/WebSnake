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
        GlobalGame.SnakeList.Add(new Snake(0.5, 0.5, snakeId));
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

    public void ChangeSnakeMoveDirection(int id, MoveDirection newDirection)
    {
        GlobalGame.SnakeList[id].SnakeMoveDirection = newDirection;
    }

    //This method makes head of snakes to move
    public void MovingSnakeMain()
    {
        var snakeList = GlobalGame.SnakeList;

        for (int index = 0; index < GlobalGame.SnakeList.Count(); index++)
        {
            var currentSnakeObject = snakeList[index];
            if (currentSnakeObject.SnakeMoveDirection == MoveDirection.None)
            {
                continue;
            }

            if (currentSnakeObject.SnakeMoveDirection == MoveDirection.Up && currentSnakeObject.SnakeMoveDirection != MoveDirection.Down)
            {
                snakeList[index].VerticalPosition += currentSnakeObject.SnakeMoveSpeed;
                snakeList[index].VerticalPosition = Math.Round(snakeList[index].VerticalPosition, 2);
                MovingSnakeOther(index);
            }
            else if (currentSnakeObject.SnakeMoveDirection == MoveDirection.Down && currentSnakeObject.SnakeMoveDirection != MoveDirection.Up)
            {
                snakeList[index].VerticalPosition -= currentSnakeObject.SnakeMoveSpeed;
                snakeList[index].VerticalPosition = Math.Round(snakeList[index].VerticalPosition, 2);
                MovingSnakeOther(index);
            }
            else if (currentSnakeObject.SnakeMoveDirection == MoveDirection.Right && currentSnakeObject.SnakeMoveDirection != MoveDirection.Left)
            {
                snakeList[index].HorizontalPosition += currentSnakeObject.SnakeMoveSpeed;
                snakeList[index].HorizontalPosition = Math.Round(snakeList[index].HorizontalPosition, 2);
                MovingSnakeOther(index);
            }
            else if (currentSnakeObject.SnakeMoveDirection == MoveDirection.Left && currentSnakeObject.SnakeMoveDirection != MoveDirection.Right)
            {
                snakeList[index].HorizontalPosition -= currentSnakeObject.SnakeMoveSpeed;
                snakeList[index].HorizontalPosition = Math.Round(snakeList[index].HorizontalPosition, 2);
                MovingSnakeOther(index);
            }

        }
    }

    //This part of the code makes the snakes' bodies move
    public void MovingSnakeOther(int index)
    {
        var snakeList = GlobalGame.SnakeList;
        var currentSnakeObject = snakeList[index];
        var snakePositionsLenght = currentSnakeObject.SnakeCordinateList.Count();

        for (int rawIndex = 0; rawIndex < currentSnakeObject.SnakeCordinateList.Count(); rawIndex++)
        {
            var currentSnakeCordinate = currentSnakeObject.SnakeCordinateList[rawIndex];
            if (rawIndex == 0)
            {
                currentSnakeCordinate.HorizontalPosition = currentSnakeObject.PastHorizontalPosition;
                currentSnakeCordinate.VerticalPosition = currentSnakeObject.PastVerticalPosition;
                currentSnakeObject.ReChangeSnakePastCordinates();
            }
            else
            {
                var pastCurrentSnakeCordinate = currentSnakeObject.SnakeCordinateList[rawIndex - 1];
                currentSnakeCordinate.HorizontalPosition = pastCurrentSnakeCordinate.PastHorizontalPosition;
                currentSnakeCordinate.VerticalPosition = pastCurrentSnakeCordinate.PastVerticalPosition;
                pastCurrentSnakeCordinate.PastHorizontalPosition = pastCurrentSnakeCordinate.HorizontalPosition;
                pastCurrentSnakeCordinate.PastVerticalPosition = pastCurrentSnakeCordinate.VerticalPosition;

                if (rawIndex + 1 == currentSnakeObject.SnakeCordinateList.Count() - 1)
                {
                    var futureCurrentSnakeCordinate = currentSnakeObject.SnakeCordinateList[rawIndex + 1];
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


    public void CheckContactedOnMapObjects()
    {

    }

    public void CheckDangerObjects(int snakeIndex)
    {
        var snakeList = GlobalGame.SnakeList;
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
                double checkerSnakesHorizontalPosition = Math.Round(Math.Abs(checkingSnakeMainBodyPositions.HorizontalPosition - horizontalOtherSnakePosition), 2);
                double checkerSnakesVerticalPosition = Math.Round(Math.Abs(checkingSnakeMainBodyPositions.VerticalPosition - verticalOtherSnakePosition), 2);

                if (checkerSnakesVerticalPosition <= 0.02 && checkerSnakesHorizontalPosition <= 0.02) 
                {
                    int snakeId = snakeList[snakeIndex].SnakeId;
                    DeleteSnake(snakeId);
                    return;
                }
            }
        }
    }
}