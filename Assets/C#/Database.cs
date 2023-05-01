using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Database", fileName = "Database")]
public class Database : ScriptableObject
{
    [SerializeField] private Color[] _sectionColors;
    [SerializeField] private Document[] _documents;

    public Color GetRandomColor() => _sectionColors[Random.Range(0, _sectionColors.Length)];

    public Document GetRandomDocument() => _documents[Random.Range(0, _documents.Length)];
}
