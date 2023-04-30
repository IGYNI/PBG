using System;
using UnityEngine;

[Serializable]
public class BoxInfo
{
    public Color Color { get; set; }
    public int CarIndex { get; set; }
    //public Sprite Sticker { get; set; }

    public BoxInfo(Color color, /*Sprite sprite,*/ int carIndex)
    {
        Color = color;
        //Sticker = sprite;
        CarIndex = carIndex;
    }
}
