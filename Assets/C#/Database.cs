using UnityEngine;

[CreateAssetMenu(menuName = "Database", fileName = "Database")]
public class Database : ScriptableObject
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private Sprite[] _stickers;

    public Color GetRandomColor() => _colors[Random.Range(0, _colors.Length)];

    public Sprite GetRandomSticker() => _stickers[Random.Range(0, _stickers.Length)];
}