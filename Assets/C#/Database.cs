using UnityEngine;

[CreateAssetMenu(menuName = "Database", fileName = "Database")]
public class Database : ScriptableObject
{
    [SerializeField] private Color[] _colors;

    public Color GetRandomColor() => _colors[UnityEngine.Random.Range(0, _colors.Length)];
}