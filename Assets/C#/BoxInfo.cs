using System;
using UnityEngine;

[Serializable]
public class BoxInfo
{
    public Color Color { get; set; }
    public Document Document { get; set; }
    public int CarIndex { get; set; }

    public BoxInfo(Color color, Document document, int carIndex)
    {
        Color = color;
        Document = document;
        CarIndex = carIndex;
    }
}
