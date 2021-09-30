using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BoardObject
/// </summary>
public class BoardObject
{
    public BoardObject(double horizontalPosition = 0.5, double verticalPosition = 0.5)
    {
        HorizontalPosition = horizontalPosition;
        VerticalPosition = verticalPosition;
    }

    public double HorizontalPosition { get; set; }

    public double VerticalPosition { get; set; }

    public NameOfEntity Entity { get; set; }
}