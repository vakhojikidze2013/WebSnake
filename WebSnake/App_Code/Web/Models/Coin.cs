using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Coin
/// </summary>
public class Coin : BoardObject
{
    public Coin()
    {

    }

    public Coin(double horizontalPosition, double verticalPosition) : base(horizontalPosition, verticalPosition)
    {
        Entity = NameOfEntity.Coin;
    }
}