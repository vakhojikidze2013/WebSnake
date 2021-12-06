using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConvertClass
/// </summary>
public static class ConvertClass
{
    public static List<ConvertSnakeModel> ConvertValue(List<Snake> value)
    {
        List<ConvertSnakeModel> convertedValues = new List<ConvertSnakeModel>();
        ConvertSnakeModel convertValue;

        foreach (var item in value)
        {
            var playerObj = PlayerManager.Current.PlayerList.FirstOrDefault(opt => opt.SnakeId == item.SnakeId);
            convertValue = new ConvertSnakeModel
            {
                HorizontalPosition = item.HorizontalPosition,
                VerticalPosition = item.VerticalPosition,
                PastHorizontalPosition = item.PastHorizontalPosition,
                PastVerticalPosition = item.PastVerticalPosition,
                SnakeCordinatesList = item.SnakeCordinateList,
                NickName = playerObj.InGameName,
                Color = playerObj.SnakeSwitchedColor
            };
            convertedValues.Add(convertValue);
        }
        return convertedValues;
    }
}