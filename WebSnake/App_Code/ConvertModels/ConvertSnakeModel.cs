using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConvertSnakeModel
/// </summary>
public class ConvertSnakeModel
{

    public double HorizontalPosition { get; set; }

    public double VerticalPosition { get; set; }

    public double PastHorizontalPosition { get; set; }

    public double PastVerticalPosition { get; set; }

    public List<SnakeCordinates> SnakeCordinatesList { get; set; }

}