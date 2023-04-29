using UnityEngine;

[CreateAssetMenu(menuName = "Box Info", fileName = "New Box")]
public class BoxInfo : ScriptableObject
{
    [field: SerializeField ] public Color Color { get; private set; }
}
