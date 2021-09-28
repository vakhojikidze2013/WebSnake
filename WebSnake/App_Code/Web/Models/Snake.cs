using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Snake
/// </summary>
public class Snake : BoardObject
{
    public Snake(double horizontalPosition, double verticalPosition) : base(horizontalPosition, verticalPosition)
    {
        SnakeLength = 3;
        Entity = NameOfEntity.Snake;
        SnakeMoveDirection = MoveDirection.None;
        SnakeMoveSpeed = 
    }

    public int SnakeLength { get; set; }

    public MoveDirection SnakeMoveDirection { get; set; }
}