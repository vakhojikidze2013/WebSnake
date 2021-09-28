using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BoardObject
/// </summary>
public class BoardObject
{
    public BoardObject(double horizontalPosition, double verticalPosition)
    {
        HorizontalPosition = horizontalPosition;
        VerticalPosition = verticalPosition;
    }

    public double HorizontalPosition { get; set; }

    public double VerticalPosition { get; set; }

    public NameOfEntity Entity { get; set; }
}