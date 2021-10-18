using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Snake
/// </summary>
public class Snake : BoardObject
{
    public Snake(double horizontalPosition, double verticalPosition, int snakeId) : base(horizontalPosition, verticalPosition)
    {
        SnakeLength = 3;
        Entity = NameOfEntity.Snake;
        SnakeMoveDirection = MoveDirection.Up;
        SnakeMoveSpeed = MoveSpeed.Slow;
        SnakeId = snakeId;
        SnakeCordinateList = new List<SnakeCordinates>();
        ReChangeSnakePastCordinates();
        SetSnakeStartPositions(horizontalPosition, verticalPosition);
    }

    public int SnakeLength { get; set; }

    public MoveDirection SnakeMoveDirection { get; set; }

    public double SnakeMoveSpeed { get; set; }

    public double PastHorizontalPosition { get; set; }

    public double PastVerticalPosition { get; set; }

    public int SnakeId { get; set; }

    public List<SnakeCordinates> SnakeCordinateList { get; set; }

    public void SetSnakeStartPositions(double mainHorizontalPosition, double mainVerticalPosition)
    {
        SnakeCordinateList.Add(new SnakeCordinates
        {
            HorizontalPosition = mainHorizontalPosition,
            VerticalPosition = mainVerticalPosition - SnakeMoveSpeed,
            PastHorizontalPosition = mainHorizontalPosition,
            PastVerticalPosition = mainVerticalPosition - SnakeMoveSpeed
        });

        SnakeCordinateList.Add(new SnakeCordinates
        {
            HorizontalPosition = mainHorizontalPosition,
            VerticalPosition = mainVerticalPosition - SnakeMoveSpeed * 2,
            PastHorizontalPosition = mainHorizontalPosition,
            PastVerticalPosition = mainVerticalPosition - SnakeMoveSpeed * 2
        });

        SnakeCordinateList.Add(new SnakeCordinates
        {
            HorizontalPosition = mainHorizontalPosition,
            VerticalPosition = mainVerticalPosition - SnakeMoveSpeed * 3,
            PastHorizontalPosition = mainHorizontalPosition,
            PastVerticalPosition = mainVerticalPosition - SnakeMoveSpeed * 3
        });
    }

    public void ReChangeSnakePastCordinates()
    {
        PastHorizontalPosition = HorizontalPosition;
        PastVerticalPosition = VerticalPosition;
    }

    public void AddSnakeNewStartPositions()
    {
        int lastIndex = SnakeCordinateList.Count - 1;

        if (Math.Round(SnakeCordinateList[lastIndex - 1].HorizontalPosition - SnakeCordinateList[lastIndex - 2].HorizontalPosition, 2) < 0)
        {
            //right
            SnakeCordinateList.Add(new SnakeCordinates
            {
                HorizontalPosition = SnakeCordinateList[lastIndex].HorizontalPosition - SnakeMoveSpeed,
                VerticalPosition = SnakeCordinateList[lastIndex].VerticalPosition,
                PastHorizontalPosition = SnakeCordinateList[lastIndex].HorizontalPosition - SnakeMoveSpeed,
                PastVerticalPosition = SnakeCordinateList[lastIndex].VerticalPosition
            });
        } 
        else if (Math.Round(SnakeCordinateList[lastIndex - 1].HorizontalPosition - SnakeCordinateList[lastIndex - 2].HorizontalPosition, 2) > 0)
        {
            //left
            SnakeCordinateList.Add(new SnakeCordinates
            {
                HorizontalPosition = SnakeCordinateList[lastIndex].HorizontalPosition + SnakeMoveSpeed,
                VerticalPosition = SnakeCordinateList[lastIndex].VerticalPosition,
                PastHorizontalPosition = SnakeCordinateList[lastIndex].HorizontalPosition + SnakeMoveSpeed,
                PastVerticalPosition = SnakeCordinateList[lastIndex].VerticalPosition
            });
        } 
        else if (Math.Round(SnakeCordinateList[lastIndex - 1].VerticalPosition - SnakeCordinateList[lastIndex - 2].VerticalPosition, 2) < 0)
        {

            SnakeCordinateList.Add(new SnakeCordinates
            {
                HorizontalPosition = SnakeCordinateList[lastIndex].HorizontalPosition,
                VerticalPosition = SnakeCordinateList[lastIndex].VerticalPosition - SnakeMoveSpeed,
                PastHorizontalPosition = SnakeCordinateList[lastIndex].HorizontalPosition,
                PastVerticalPosition = SnakeCordinateList[lastIndex].VerticalPosition - SnakeMoveSpeed
            });
        }
        else if (Math.Round(SnakeCordinateList[lastIndex - 1].VerticalPosition - SnakeCordinateList[lastIndex - 2].VerticalPosition, 2) > 0)
        {
            SnakeCordinateList.Add(new SnakeCordinates
            {
                HorizontalPosition = SnakeCordinateList[lastIndex].HorizontalPosition,
                VerticalPosition = SnakeCordinateList[lastIndex].VerticalPosition + SnakeMoveSpeed,
                PastHorizontalPosition = SnakeCordinateList[lastIndex].HorizontalPosition,
                PastVerticalPosition = SnakeCordinateList[lastIndex].VerticalPosition + SnakeMoveSpeed
            });
        }
    }
}