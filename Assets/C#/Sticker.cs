using System;
using UnityEngine;

[Serializable]
public class Sticker
{
    [field: SerializeField] public ItemType Type { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}
