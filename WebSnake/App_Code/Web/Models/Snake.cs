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
        SnakeMoveDirection = MoveDirection.None;
        SnakeMoveSpeed = MoveSpeed.Slow;
        SnakeId = snakeId;
        SnakeCordinateList = new List<SnakeCordinates>();
        ReChangeSnakePastCordinates();
        SetSnakeStartPositions();
    }

    public int SnakeLength { get; set; }

    public MoveDirection SnakeMoveDirection { get; set; }

    public double SnakeMoveSpeed { get; set; }

    public double PastHorizontalPosition { get; set; }

    public double PastVerticalPosition { get; set; }

    public int SnakeId { get; set; }

    public List<SnakeCordinates> SnakeCordinateList { get; set; }

    public void SetSnakeStartPositions()
    {
        SnakeCordinateList.Add(new SnakeCordinates
        {
            HorizontalPosition = 0.50,
            VerticalPosition = 0.49,
            PastHorizontalPosition = 0.50,
            PastVerticalPosition = 0.49
        });

        SnakeCordinateList.Add(new SnakeCordinates
        {
            HorizontalPosition = 0.50,
            VerticalPosition = 0.48,
            PastHorizontalPosition = 0.50,
            PastVerticalPosition = 0.48
        });

        SnakeCordinateList.Add(new SnakeCordinates
        {
            HorizontalPosition = 0.50,
            VerticalPosition = 0.47,
            PastHorizontalPosition = 0.50,
            PastVerticalPosition = 0.47
        });
    }

    public void ReChangeSnakePastCordinates()
    {
        PastHorizontalPosition = HorizontalPosition;
        PastVerticalPosition = VerticalPosition;
    }
}