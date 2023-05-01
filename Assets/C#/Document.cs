using System;
using UnityEngine;

[Serializable]
public class Document
{
    [field: SerializeField] public ItemType Type { get; private set; }
    [field: SerializeField] public string Text { get; private set; }
    [field: SerializeField] public Sprite[] Stickers { get; private set; }
}