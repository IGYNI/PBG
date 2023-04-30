using System;
using UnityEngine;

[Serializable]
public class BoxInfo
{
    public Color Color { get; set; }
    public int CarIndex { get; set; }

    public BoxInfo(Color color, int carIndex)
    {
        Color = color;
        CarIndex = carIndex;
    }
}
