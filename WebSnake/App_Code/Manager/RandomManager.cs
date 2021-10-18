using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RandomManager
/// </summary>
public static class RandomManager
{
    public static double GetRandomNumber(double minimum = 10.0, double maximum = 99.0)
    {
        Random random = new Random();
        return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, 2);
    }
}